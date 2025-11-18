using gozba_na_klik_backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IOrderRepository
    {
        Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime OrderTime);
        Task<Order> GetActiveOrderByCourierIdAsync(int courierId);
        Task<Order> GetByIdAsync(int orderId);
        Task<Order> UpdateCourierActiveOrderStatusAsync(Order order);
    }
}
