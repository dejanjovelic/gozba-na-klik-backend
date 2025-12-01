using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IRestaurantService
    {
        Task<PaginatedListDto<Restaurant>> GetAllFilteredAndSortedAndPagedAsync(RestaurantFilterDto restaurantFilter, int sortType, int page, int pageSize);
        Task<PaginatedListDto<Restaurant>> GetAllRestaurantsPaginatedAsync(int page, int pageSize);
        List<RestaurantSortTypeOptionDto> GetAllSortTypes();
        Task<RestaurantWithMealsDto> GetRestaurantWithMealsAsync(int restaurantId);
        bool IsRestaurantOpen(Restaurant restaurant);
        Task UpdateRestaurantAverageRatingAsync(int restaurantId);
    }
}