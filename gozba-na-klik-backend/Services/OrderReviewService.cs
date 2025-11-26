using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
namespace gozba_na_klik_backend.Services
{
    public class OrderReviewService : IOrderReviewService
    {
        public readonly IOrderReviewRepository _orderReviewRepository;
        public OrderReviewService(IOrderReviewRepository orderReviewRepository)
        {
            _orderReviewRepository = orderReviewRepository;
        }
        public async Task CreateOrderReviewAsync(OrderReview orderReview)
        {
            if (orderReview == null)
            {
                throw new ArgumentNullException("Order review cannot be null.");
            }
            if(orderReview.RestaurantRating > 10 || orderReview.RestaurantRating < 0 ||orderReview.CourierRating > 10 || orderReview.CourierRating < 0)
            {
                throw new ArgumentOutOfRangeException("Rating has to be between 0 or 10");
            }
            await _orderReviewRepository.CreateOrderReviewAsync(orderReview);
        }
    }
}
