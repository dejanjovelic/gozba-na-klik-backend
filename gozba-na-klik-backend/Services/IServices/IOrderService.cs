using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using System;
using System.Threading.Tasks;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IOrderService
    {
        Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime? OrderTime);
        Task AssignOrderToCourierAsync();
    }
}