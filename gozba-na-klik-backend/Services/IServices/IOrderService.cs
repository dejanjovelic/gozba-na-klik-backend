using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IOrderService
    {
        Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId);
        Task EditOrderStatusAsync(int orderId, OrderStatus newStatus, TimeSpan OrderTime);
        
    }
}