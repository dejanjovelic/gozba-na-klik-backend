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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IMealService mealService, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _mealService = mealService;
            _httpContextAccessor = httpContextAccessor;
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


        public async Task<CourierOrderDto> UpdateOrderStatusAsync(int orderId, UpdateOrderDTO dto, string? authenticatedUserId)
        {
            var roles = GetUserRoles();

            if (orderId == 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            Order order = await _orderRepository.GetByIdAsync(orderId);

            ValidateActiveOrderUpdateData(orderId, dto.NewStatus, authenticatedUserId, order, roles);
            
            order.Status = dto.NewStatus;

            if (roles.Contains("Customer"))
            {
                //TO DO treba mi vreme za update
            }
            else if (roles.Contains("RestaurantOwner"))
            {
                //TO DO treba mi vreme za update
            }
            else if (roles.Contains("Courier"))
            {
                if (dto.NewStatus.ToString().Trim().ToLower() == "deliveryinprogress")
                {
                    order.DeliveryStartedAt = dto.NewTime;
                }
                else if (dto.NewStatus.ToString().Trim().ToLower() == "delivered")
                {
                    order.DeliveredAt = dto.NewTime;
                }
            }

            Order updatedOrder = await _orderRepository.UpdateOrderStatusAsync(order);
            return _mapper.Map<CourierOrderDto>(updatedOrder);
        }

        private List<string> GetUserRoles()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                return new List<string>();
            }
            var roles = user.Claims
                            .Where(c => c.Type == "role")
                            .Select(c => c.Value)
                            .ToList();
            return roles;
        }

        private static void ValidateActiveOrderUpdateData(int orderId, OrderStatus newStatus, string? authenticatedUserId, Order order, List<string> roles)
        {
            if (order == null)
            {
                throw new NotFoundException($"Order with Id:{orderId} not found.");
            }

            if (roles.Contains("RestaurantOwner"))
            {
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

            if (roles.Contains("Courier")) 
            {
                if (order.CourierId != authenticatedUserId)
                {
                    throw new ForbiddenException($"Courier with Id: {authenticatedUserId} is not authorized to update order with ID: {orderId}.");
                }

                if (order.Status != OrderStatus.PickupInProgress && order.Status != OrderStatus.DeliveryInProgress)
                {
                    throw new BadRequestException($"Courier can only modify orders that are in 'Pickup in progress' or  'Delivery In Progress' status.");
                }

                if (newStatus != OrderStatus.DeliveryInProgress && newStatus != OrderStatus.Delivered)
                {
                    throw new BadRequestException("Status of order must be either 'Delivery in progress'  or 'Delivered'.");
                }
            }

            if (roles.Contains("Customer"))
            {
                if (order.CustomerId != authenticatedUserId)
                {
                    throw new ForbiddenException($"Customer with Id: {authenticatedUserId} is not authorized to update order with ID: {orderId}.");
                }

                if (order.Status != OrderStatus.Pending)
                {
                    throw new BadRequestException($"Customer can only modify orders that are in 'Pending' status.");
                }

                if (newStatus != OrderStatus.Cancelled)
                {
                    throw new BadRequestException("Customer can change status of order only in 'Canceled'.");
                }
            }
        }

        public async Task<CourierOrderDto> GetActiveOrderByCourierIdAsync(string courierId, string? authenticatedUserId)
        {
            if (string.IsNullOrWhiteSpace(courierId))
            {
                throw new BadRequestException("Invalid courier data.");
            }
            if (courierId != authenticatedUserId)
            {
                throw new ForbiddenException($"You are not allowed to access another courier's orders.");
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
    }
}