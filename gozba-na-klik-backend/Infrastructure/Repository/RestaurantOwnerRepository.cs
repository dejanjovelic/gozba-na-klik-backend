using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Infrastructure.Repository
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

        public async Task<RestaurantOwner> GetByIdAsync(string restaurantOwnerId)
        {
            return await _context.RestaurantOwners
                 .Include(restaurantOwner => restaurantOwner.ApplicationUser)
                 .FirstOrDefaultAsync(restaurantOwner => restaurantOwner.Id == restaurantOwnerId);
        }

        public async Task<bool> RestaurantOwnerExistsByIdAsync(string id)
        {
            return await _context.RestaurantOwners
                 .AnyAsync(ro => ro.Id == id);
        }

        public async Task<List<RestaurantOwner>> GetAllAsync() 
        {
            return await _context.RestaurantOwners
                .Include(ro => ro.ApplicationUser).ToListAsync();
        }
    }
}
