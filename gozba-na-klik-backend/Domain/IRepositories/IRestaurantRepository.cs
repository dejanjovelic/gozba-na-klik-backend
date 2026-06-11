using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.RestaurantDtos;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetTopRatedRestaurantsAsync();
        Task<PaginatedListDto<Restaurant>> GetAllRestaurantsPaginatedAsync(int page, int pageSize);
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<List<Restaurant>> GetAllRestaurantsByOwnerIdAsync(string ownerId);
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task<PaginatedListDto<Restaurant>> GetAllFilteredAndSortedAndPagedAsync(RestaurantFilterDto restaurantFilter, int sortType, int page, int pageSize);
        Task<int> CountAllRestaurantsAsync();
        Task<Restaurant> CreateRestaurantAsync(Restaurant newRestaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(Restaurant restaurant);
        Task<bool> RestaurantExistsAsync(int id);
      
    }
}
