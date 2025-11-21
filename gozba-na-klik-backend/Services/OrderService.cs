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

        public async Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(string ownerId, string? currentOwnerId)
        {
            if (ownerId != currentOwnerId)
            {
                throw new ForbiddenException($"Restaurant owner with Id: {ownerId} do not have permission to perform this action.");
            }

            if (string.IsNullOrWhiteSpace(ownerId))
            {
                throw new BadRequestException("Invalid data.");
            }

            return await _orderRepository.GetOrdersByOwnerIdAsync(ownerId);
        }


        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime orderTime, string? authenticatedUserId)
        {
            if (orderId == 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            Order order = await _orderRepository.GetByIdAsync(orderId);

            ValidateRestaurantOwnerUpdateData(orderId, newStatus, authenticatedUserId, order);

            await _orderRepository.UpdateOrderStatusAsync(orderId, newStatus, orderTime);
        }

        private static void ValidateRestaurantOwnerUpdateData(int orderId, OrderStatus newStatus, string? authenticatedUserId, Order order)
        {
            if (order == null)
            {
                throw new NotFoundException($"Order with Id:{orderId} not found.");
            }

            if (order.Restaurant.RestaurantOwnerId != authenticatedUserId)
            {
                throw new ForbiddenException($"Restaurant owner with Id: {authenticatedUserId} do not have permission to access this order.");
            }

            if (order.Status != OrderStatus.Pending)
            {
                throw new ForbiddenException("Restaurant owner can only modify orders that are in 'Pending' status.");
            }

            if (newStatus != OrderStatus.Cancelled && newStatus != OrderStatus.Accepted)
            {
                throw new ArgumentException("Status must be either Denied or Accepted", nameof(newStatus));
            }
        }

        public async Task<CourierOrderDto> GetActiveOrderByCourierIdAsync(string courierId, string? authenticatedUserId)
        {
            if (string.IsNullOrWhiteSpace(courierId))
            {
                throw new BadRequestException("Invalid courier data.");
            }

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

        public async Task<CourierOrderDto> UpdateCourierActiveOrderStatusAsync(int orderId, UpdateOrderDTO updateOrder, string? authenticatedUserId)
        {
            if (orderId <= 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            Order order = await _orderRepository.GetByIdAsync(orderId);

            ValidateCourierOrderUpdateData(orderId, authenticatedUserId, updateOrder, order);

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

        private static void ValidateCourierOrderUpdateData(int orderId, string? authenticatedUserId, UpdateOrderDTO updateOrder, Order order)
        {
            if (order == null)
            {
                throw new NotFoundException($"Order with Id: {order.Id} not found.");
            }

            if (order.CourierId != authenticatedUserId)
            {
                throw new ForbiddenException($"Courier with Id: {authenticatedUserId} is not authorized to update order with ID: {orderId}.");
            }

            if (order.Status != OrderStatus.PickupInProgress && order.Status != OrderStatus.DeliveryInProgress)
            {
                throw new BadRequestException($"Courier can only modify orders that are in 'Pickup in progress' or  'Delivery In Progress' status.");
            }

            if (updateOrder.NewStatus != OrderStatus.DeliveryInProgress && updateOrder.NewStatus != OrderStatus.Delivered)
            {
                throw new BadRequestException("Status of order must be either 'Delivery in progress'  or 'Delivered'.");
            }
        }
    }
}