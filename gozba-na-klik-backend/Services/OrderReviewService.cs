using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
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

        public async Task<PaginatedListDto<OrderReviewResponseDto>> GetPagedReviewsByRestaurantIdAsync(OrderReviewRequestDto dto)
        {
            var restaurant = await _restaurantService.GetRestaurantWithMealsAsync(dto.RestaurantId);
            if (restaurant == null) throw new NotFoundException($"Restaurant with ID {dto.RestaurantId} not found.");

            var repoReviews = await _orderReviewRepository.GetPagedReviewByRestaurantIdAsync(dto.RestaurantId, dto.Page);

            PaginatedListDto<OrderReviewResponseDto> result = new PaginatedListDto<OrderReviewResponseDto>
            {
                Items = _mapper.Map<List<OrderReviewResponseDto>>(repoReviews.Items),
                PageIndex = repoReviews.PageIndex,
                TotalPages = repoReviews.TotalPages,
                TotalRowsCount = repoReviews.TotalRowsCount,
                HasNextPage = repoReviews.HasNextPage,
                HasPreviousPage = repoReviews.HasPreviousPage
            };

            return result;
        }

        public async Task<int> GetReviewCountForRestaurantAsync(int restaurantId)
        {
            var restaurant = await _restaurantService.GetRestaurantWithMealsAsync(restaurantId);
            if (restaurant == null) throw new NotFoundException($"Restaurant with ID {restaurantId} not found.");

            return await _orderReviewRepository.GetReviewCountForRestaurantAsync(restaurantId);
        }
    }
}
