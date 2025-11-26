using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IOrderReviewService
    {
        Task CreateOrderReviewAsync(OrderReview orderReview);
    }
}