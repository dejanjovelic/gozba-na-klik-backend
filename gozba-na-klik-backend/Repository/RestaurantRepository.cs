using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
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
        public async Task<PaginatedListDto<Restaurant>> GetAllFilteredAndSortedAndPagedAsync(RestaurantFilterDto restaurantFilter, int sortType, int page, int pageSize) 
        {
            IQueryable<Restaurant> restaurants = _context.Restaurants
                .OrderBy(restaurant => restaurant.Id);

            restaurants = FilterRestaurants(restaurants, restaurantFilter);
            restaurants = SortedRestaurants(restaurants, sortType);

            int pageIndex = page - 1;
            int totalRowsCount = await restaurants.CountAsync();
            var item = await restaurants.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            PaginatedListDto<Restaurant> paginatedRestaurantListDto = new PaginatedListDto<Restaurant>(item, totalRowsCount, pageIndex, pageSize);
            return paginatedRestaurantListDto;
        }

        public async Task<int> CountAllRestaurantsAsync() 
        {
            return await _context.Restaurants.CountAsync();
        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(int restaurantId)
        {
            return await _context.Restaurants
                .Include(r => r.WorkingHours)
                .Include(r => r.MealsOnMenu)
                .ThenInclude(m => m.Allergens)
                .FirstOrDefaultAsync(r => r.Id == restaurantId);
        }

        private static IQueryable<Restaurant> FilterRestaurants(IQueryable<Restaurant> restaurants, RestaurantFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                restaurants = restaurants.Where(restaurant => restaurant.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(filter.City))
            {
                restaurants = restaurants.Where(restaurant => restaurant.City.ToLower().Contains(filter.City.ToLower()));
            }
            if (filter.CapacityFrom != null)
            {
                restaurants = restaurants.Where(restaurant => restaurant.Capacity >= filter.CapacityFrom);
            }
            if (filter.CapacityTo != null)
            {
                restaurants = restaurants.Where(restaurant => restaurant.Capacity <= filter.CapacityTo);
            }
            if (filter.AverageRatingform != null)
            {
                restaurants = restaurants.Where(restaurant => restaurant.AverageRating >= filter.AverageRatingform);
            }
            if (filter.AverageRatingTo != null)
            {
                restaurants = restaurants.Where(restaurants => restaurants.AverageRating <= filter.AverageRatingTo);
            }
            return restaurants;
        }

        private static IQueryable<Restaurant> SortedRestaurants(IQueryable<Restaurant> restaurants, int sortType)
        {
            return sortType switch
            {
                (int)RestaurantSortType.NAME_ASC => restaurants.OrderBy(restaurant => restaurant.Name),
                (int)RestaurantSortType.NAME_DESC => restaurants.OrderByDescending(restaurant => restaurant.Name),
                (int)RestaurantSortType.CAPACITY_ASC => restaurants.OrderBy(restaurant => restaurant.Capacity),
                (int)RestaurantSortType.CAPACITY_DESC => restaurants.OrderByDescending(restaurant => restaurant.Capacity),
                (int)RestaurantSortType.AVERAGE_RATING_ASC => restaurants.OrderBy(restaurant => restaurant.AverageRating),
                (int)RestaurantSortType.AVERAGE_RATING_DECS => restaurants.OrderByDescending(restaurant => restaurant.AverageRating),
                _ => restaurants.OrderBy(restaurant => restaurant.Name)
            };
        }
        public async Task UpdateRestaurantAverageRatingAsync(int restaurantId)
        {
            var restaurant = await GetRestaurantByIdAsync(restaurantId);
            var reviews = restaurant.Orders
                .Where(o => o.OrderReview != null)
                .Select(o => o.OrderReview!.RestaurantRating)
                .ToList();

            restaurant.AverageRating = reviews.Count > 0 ? reviews.Average() : 0;
            await _context.SaveChangesAsync();
        }
    }
}
