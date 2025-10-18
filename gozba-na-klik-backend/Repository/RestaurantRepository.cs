using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Repository
{
    public class RestaurantRepository:IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedListDto<Restaurant>> GetAllRestaurantsPaginatedAsync(int page, int pageSize)
        {
            IQueryable<Restaurant> restaurants = _context.Restaurants
                .OrderBy(restaurant => restaurant.Id);

            int pageIndex = page - 1;
            int totalRowsCount = await _context.Restaurants.CountAsync();
            List<Restaurant> selectedRestaurants = restaurants.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            PaginatedListDto<Restaurant> result = new PaginatedListDto<Restaurant>(selectedRestaurants, totalRowsCount, pageIndex, pageSize);
            return result;
        }
        public async Task<IQueryable<Restaurant>> GetBaseRestaurantsAsync() 
        {
            IQueryable<Restaurant> restaurants = _context.Restaurants
                .OrderBy(restaurant => restaurant.Id);
            return restaurants;
        }

        public async Task<int> CountAllRestaurantsAsync() 
        {
            return await _context.Restaurants.CountAsync();
        }
    }
}
