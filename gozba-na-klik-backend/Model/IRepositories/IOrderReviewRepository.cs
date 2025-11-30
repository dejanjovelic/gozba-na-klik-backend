using gozba_na_klik_backend.DTOs;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IOrderReviewRepository
    {
        Task CreateOrderReviewAsync(OrderReview orderReview);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<PaginatedListDto<OrderReview>> GetPagedReviewByRestaurantIdAsync(int restaurantId, int page);
    }
}
