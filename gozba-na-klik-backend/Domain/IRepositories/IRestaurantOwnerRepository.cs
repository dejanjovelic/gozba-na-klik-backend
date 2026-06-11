using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IRestaurantOwnerRepository
    {
        Task<RestaurantOwner> CreateAsync(RestaurantOwner restaurantOwner);
        Task<List<RestaurantOwner>> GetAllAsync();
        Task<RestaurantOwner> GetByIdAsync(string restaurantOwnerId);
        Task<bool> RestaurantOwnerExistsByIdAsync(string id);
    }
}