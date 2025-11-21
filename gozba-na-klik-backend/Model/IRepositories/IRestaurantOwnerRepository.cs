using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IRestaurantOwnerRepository
    {
        Task<RestaurantOwner> CreateAsync(RestaurantOwner restaurantOwner);
    }
}