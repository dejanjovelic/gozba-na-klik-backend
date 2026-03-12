using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.Order;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IOrderReviewService
    {
        Task CreateOrderReviewAsync(CreateOrderReviewDTO orderReviewDTO);
        Task<PaginatedListDto<OrderReviewResponseDto>> GetPagedReviewsByRestaurantIdAsync(OrderReviewRequestDto dto);
    }
}