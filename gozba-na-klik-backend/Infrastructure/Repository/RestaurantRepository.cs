using gozba_na_klik_backend.Services.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.RestaurantDtos;
using gozba_na_klik_backend.Utils;

namespace gozba_na_klik_backend.Infrastructure.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetTopRatedRestaurantsAsync()
        {
            return await _context.Restaurants
                .OrderByDescending(restaurant => restaurant.AverageRating)
                .Take(10)
                .ToListAsync();
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

        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants
                .Include(r => r.Orders)
                     .ThenInclude(o => o.OrderReview)
                 .Include(r => r.WorkingHours)
                 .Include(r => r.NonWorkingDates)
                 .Include(r => r.MealsOnMenu)
                     .ThenInclude(m => m.Allergens)
                .ToListAsync();
        }

        public async Task<List<Restaurant>> GetAllRestaurantsByOwnerIdAsync(string ownerId)
        {
            return await _context.Restaurants
                .Where(r => r.RestaurantOwnerId == ownerId)
                .Include(r => r.Orders)
                     .ThenInclude(o => o.OrderReview)
                 .Include(r => r.WorkingHours)
                 .Include(r => r.NonWorkingDates)
                 .Include(r => r.MealsOnMenu)
                     .ThenInclude(m => m.Allergens)
                .ToListAsync();
        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(int restaurantId)
        {
            return await _context.Restaurants
                 .Include(r => r.Orders)
                     .ThenInclude(o => o.OrderReview)
                 .Include(r => r.WorkingHours)
                 .Include(r => r.NonWorkingDates)
                 .Include(r => r.MealsOnMenu)
                     .ThenInclude(m => m.Allergens)
                 .FirstOrDefaultAsync(r => r.Id == restaurantId);
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

        public async Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant)
        {
            _context.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(Restaurant restaurant)
        {
            _context.Remove(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RestaurantExistsAsync(int id)
        {
            return await _context.Restaurants.AnyAsync(r => r.Id == id);
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
    }
}
