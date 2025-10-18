using gozba_na_klik_backend.DTOs;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IRestaurantRepository
    {
        Task<PaginatedListDto<Restaurant>> GetAllRestaurantsPaginatedAsync(int page, int pageSize);
        Task<IQueryable<Restaurant>> GetBaseRestaurantsAsync();
        Task<int> CountAllRestaurantsAsync();
    }
}
