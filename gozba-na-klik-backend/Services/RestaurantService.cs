using System;
using System.Linq;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace gozba_na_klik_backend.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
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

            return await _restaurantRepository.GetAllFilteredAndSortedAndPagedAsync(restaurantFilter, sortType, page, pageSize);
        }



        public async Task<RestaurantWithMealsDto> GetRestaurantWithMealsAsync(int restaurantId)
        {
            Restaurant restaurant = await _restaurantRepository.GetRestaurantByIdAsync(restaurantId);

            if (restaurant == null)
            {
                throw new NotFoundException($"Restaurant with ID {restaurantId} not found.");
            }

            return _mapper.Map<RestaurantWithMealsDto>(restaurant);
        }

        public bool IsRestaurantOpen(Restaurant restaurant)
        {
            var now = DateTime.Now.TimeOfDay;
            var today = DateTime.Now.DayOfWeek;

            var todayHours = restaurant.WorkingHours
                .FirstOrDefault(w => w.DayOfTheWeek == today);

            if (todayHours == null)
                return false;

            return now >= todayHours.StartingTime && now <= todayHours.EndingTime;
        }
    }
}
