using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMealService _mealService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IMealService mealService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _mealService = mealService;
        }

        public async Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId)
        {
            if (ownerId == 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            return await _orderRepository.GetOrdersByOwnerIdAsync(ownerId);
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime orderTime)
        {
            if (orderId == 0)
                throw new BadRequestException("Invalid data.");

            if (newStatus != OrderStatus.Cancelled && newStatus != OrderStatus.Accepted)
                throw new ArgumentException("Status must be either Denied or Accepted", nameof(newStatus));

            await _orderRepository.UpdateOrderStatusAsync(orderId, newStatus, orderTime);
        }

        public async Task<CourierOrderDto> GetActiveOrderByCourierIdAsync(int courierId)
        {
            Order order = await _orderRepository.GetActiveOrderByCourierIdAsync(courierId);
            if (order == null)
            {
                throw new NotFoundException("You currently have no assigned orders.");
            }
            
            List<CourierOrderMealDto> courierOrderMeals = order.OrderItems.Select(_mapper.Map<CourierOrderMealDto>).ToList();

            CourierOrderDto courierOrderDto = _mapper.Map<CourierOrderDto>(order);
            courierOrderDto.OrderItems = courierOrderMeals;
            return courierOrderDto;
        }

        public async Task<CourierOrderDto> UpdateCourierActiveOrderStatusAsync(int orderId, int courierId, UpdateOrderDTO updateOrder)
        {
            Order order = await _orderRepository.GetByIdAsync(orderId);

            ValidateCourierOrderUpdateData(orderId, courierId, updateOrder, order);

            order.Status = updateOrder.NewStatus;

            if (order.Status == OrderStatus.PickupInProgress)
            {
                order.DeliveryStartedAt = updateOrder.NewTime;
            }
            else
            {
                order.DeliveredAt = updateOrder.NewTime;
            }

            Order updatedOrder = await _orderRepository.UpdateCourierActiveOrderStatusAsync(order);
            return _mapper.Map<CourierOrderDto>(updatedOrder);

        }

        private static void ValidateCourierOrderUpdateData(int orderId, int courierId, UpdateOrderDTO updateOrder, Order order)
        {
            if (order.CourierId != courierId)
            {
                throw new ForbiddenException($"You are not authorized to update order with ID: {orderId}.");
            }

            if (order.Status != OrderStatus.PickupInProgress && order.Status != OrderStatus.DeliveryInProgress)
            {
                throw new BadRequestException($"Order with status '{order.Status}' cannot be updated.");
            }

            if (updateOrder.NewStatus != OrderStatus.DeliveryInProgress && updateOrder.NewStatus != OrderStatus.Delivered)
            {
                throw new BadRequestException("Status of order must be either delivery in progress  or delivered");
            }
        }
    }
}