using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId)
        {
            if (ownerId == 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            return await _orderRepository.GetOrdersByOwnerIdAsync(ownerId);
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, TimeSpan orderTime)
        {
            if (orderId == 0)
                throw new BadRequestException("Invalid data.");

            if (newStatus != OrderStatus.Otkazana && newStatus != OrderStatus.Prihvacena)
                throw new ArgumentException("Status must be either Denied or Accepted", nameof(newStatus));

            await _orderRepository.UpdateOrderStatusAsync(orderId, newStatus, orderTime);
        }
    }
}