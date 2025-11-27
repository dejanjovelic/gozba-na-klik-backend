using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
namespace gozba_na_klik_backend.Services
{
    public class OrderReviewService : IOrderReviewService
    {
        public readonly IOrderReviewRepository _orderReviewRepository;
        public readonly IRestaurantService _restaurantService;
        public OrderReviewService(IOrderReviewRepository orderReviewRepository, IRestaurantService restaurantService)
        {
            _orderReviewRepository = orderReviewRepository;
            _restaurantService = restaurantService;
        }
        public async Task CreateOrderReviewAsync(OrderReview orderReview)
        {
            if (orderReview == null)
            {
                throw new ArgumentNullException("OrderReview can't be null");
            }
           
            await _orderReviewRepository.CreateOrderReviewAsync(orderReview);
            var order = await _orderReviewRepository.GetOrderByIdAsync(orderReview.OrderId);

            if (order == null)
                throw new NotFoundException("Order not found.");

            await _restaurantService.UpdateRestaurantAverageRatingAsync(order.RestaurantId);

        }
    }
}
