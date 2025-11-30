using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IOrderReviewService
    {
        Task CreateOrderReviewAsync(CreateOrderReviewDTO orderReviewDTO);
        Task<PaginatedListDto<OrderReviewResponseDto>> GetPagedReviewsByRestaurantIdAsync(OrderReviewRequestDto dto);
    }
}