using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<RestaurantOwner> GetById(string restaurantOwnerId)
        {
           return await _context.RestaurantOwners
                .Include(restaurantOwner=>restaurantOwner.ApplicationUser)
                .FirstOrDefaultAsync(restaurantOwner => restaurantOwner.Id == restaurantOwnerId);
        }
    }
}
