using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;
using System.Security.Claims;
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
        Task<byte[]> GetPdfInvoiceForOrderAsync(int orderId, string? customerId);
        Task<List<CustomerOrderResponseDto>> GetActiveOrdersByCustomerIdAsync(ClaimsPrincipal userPrincipal);
        Task<PaginatedListDto<CustomerOrderResponseDto>> GetInactiveOrdersByCustomerIdAsync(ClaimsPrincipal userPrincipal, int page, int pageSize);
        Task AssignOrderToCourierAsync();
    }
}