using gozba_na_klik_backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByOwnerIdAsync(string ownerId);
        Task<Order> UpdateOrderStatusAsync(Order order);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetByIdAsync(int orderId);
        Task<Order> GetActiveOrderByCourierIdAsync(string courierId);
    }
}
