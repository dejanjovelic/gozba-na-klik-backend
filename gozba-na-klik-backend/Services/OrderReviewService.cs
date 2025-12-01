using AutoMapper;
using gozba_na_klik_backend.DTOs;
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
        public readonly IMapper _mapper;
        public OrderReviewService(IOrderReviewRepository orderReviewRepository, IRestaurantService restaurantService, IMapper mapper)
        {
            _orderReviewRepository = orderReviewRepository;
            _restaurantService = restaurantService;
            _mapper = mapper;
        }
        public async Task CreateOrderReviewAsync(CreateOrderReviewDTO orderReviewDTO)
        {
            var orderReview = _mapper.Map<OrderReview>(orderReviewDTO);
            await _orderReviewRepository.CreateOrderReviewAsync(orderReview);
            var order = await _orderReviewRepository.GetOrderByIdAsync(orderReviewDTO.OrderId);
            if (order == null)
                throw new NotFoundException("Order not found.");
            await _restaurantService.UpdateRestaurantAverageRatingAsync(order.RestaurantId);
        }
    }
}
