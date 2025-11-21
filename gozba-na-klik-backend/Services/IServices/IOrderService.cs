using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IOrderService
    {
        Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(string ownerId, string? currentOwnerId);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime OrderTime, string? authenticatedUserId);
        Task<CourierOrderDto> GetActiveOrderByCourierIdAsync(string courierId, string? authenticatedUserId);
        Task<CourierOrderDto> UpdateCourierActiveOrderStatusAsync(int orderId, UpdateOrderDTO updateOrder, string? authenticatedUserId);
    }
}