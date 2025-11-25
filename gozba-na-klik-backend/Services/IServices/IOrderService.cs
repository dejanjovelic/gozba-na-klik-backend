using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;
using System;
using System.Threading.Tasks;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IOrderService
    {
        Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(string ownerId, string? currentOwnerId);
        Task<CourierOrderDto> UpdateOrderStatusAsync(int orderId, UpdateOrderDTO dto, string? authenticatedUserId);
        Task<ResponseOrderDto> CreateOrderAsync(CreateOrderDto dto);
        Task HandleOrderConfirmationAsync(int orderId, OrderStatus status);
        Task<CourierOrderDto> GetActiveOrderByCourierIdAsync(string courierId, string? authenticatedUserId);
        Task AssignOrderToCourierAsync();
    }
}