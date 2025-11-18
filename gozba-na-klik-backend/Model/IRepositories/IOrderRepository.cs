using gozba_na_klik_backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByOwnerIdAsync(int ownerId);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime? OrderTime); 
    }
}
