using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;

namespace gozba_na_klik_backend.Repository
{
    public class RestaurantOwnerRepository : IRestaurantOwnerRepository
    {
        public readonly AppDbContext _context;

        public RestaurantOwnerRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<RestaurantOwner> CreateAsync(RestaurantOwner restaurantOwner)
        {
            _context.Add(restaurantOwner);
            await _context.SaveChangesAsync();
            return restaurantOwner;
        }
    }
}
