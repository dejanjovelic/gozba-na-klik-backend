using System;
using System.Linq;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<PaginatedListDto<Restaurant>> GetAllRestaurantsPaginatedAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new BadRequestException("Invalid pagination parameter: 'page' must be a positive integer.");
            }
            if (pageSize < 1)
            {
                throw new BadRequestException("Invalid pagination parameter: 'pageSize' must be a positive integer.");
            }
            return await _restaurantRepository.GetAllRestaurantsPaginatedAsync(page, pageSize);
        }

        public List<RestaurantSortTypeOptionDto> GetAllSortTypes()
        {
            List<RestaurantSortTypeOptionDto> restaurantSortTypeOptions = new List<RestaurantSortTypeOptionDto>();
            var enumValues = Enum.GetValues(typeof(RestaurantSortType));
            foreach (RestaurantSortType sortType in enumValues)
            {
                restaurantSortTypeOptions.Add(new RestaurantSortTypeOptionDto(sortType));
            }
            return restaurantSortTypeOptions;
        }
        public async Task<PaginatedListDto<Restaurant>> GetAllFilteredAndSortedAndPagedAsync(RestaurantFilterDto restaurantFilter, int sortType, int page, int pageSize)
        {
            if (page < 1)
            {
                throw new BadRequestException("Invalid pagination parameter: 'page' must be a positive integer.");
            }
            if (pageSize < 1)
            {
                throw new BadRequestException("Invalid pagination parameter: 'pageSize' must be a positive integer.");
            }

            var baseRestaurants = await _restaurantRepository.GetBaseRestaurantsAsync();

            var restaurants = FilterRestaurants(baseRestaurants, restaurantFilter);
            restaurants = SortedRestaurants(restaurants, sortType);

            int pageIndex = page - 1;
            int totalRowsCount = await restaurants.CountAsync();
            var item = await restaurants.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            PaginatedListDto<Restaurant> paginatedRestaurantListDto = new PaginatedListDto<Restaurant>(item, totalRowsCount, pageIndex, pageSize);
            return paginatedRestaurantListDto;
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
            if (filter.CapcityFrom != null && filter.CapcityFrom > 0)
            {
                restaurants = restaurants.Where(restaurant => restaurant.Capacity >= filter.CapcityFrom);
            }
            if (filter.CapcityTo != null && filter.CapcityTo > 0)
            {
                restaurants = restaurants.Where(restaurant => restaurant.Capacity <= filter.CapcityTo);
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
                _ => restaurants.OrderBy(restaurant => restaurant.Name),
            };
        }
    }
}
