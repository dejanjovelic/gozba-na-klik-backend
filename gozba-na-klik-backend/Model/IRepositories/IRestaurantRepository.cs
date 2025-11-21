using gozba_na_klik_backend.DTOs;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IRestaurantRepository
    {
        Task<PaginatedListDto<Restaurant>> GetAllRestaurantsPaginatedAsync(int page, int pageSize);
        Task<PaginatedListDto<Restaurant>> GetAllFilteredAndSortedAndPagedAsync(RestaurantFilterDto restaurantFilter, int sortType, int page, int pageSize);
        Task<int> CountAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int id);
    }
}
