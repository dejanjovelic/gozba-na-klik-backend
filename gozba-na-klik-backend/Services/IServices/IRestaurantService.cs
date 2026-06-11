using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.RestaurantDtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDto>> GetTopRatedRestaurantsAsync();
        Task<PaginatedListDto<Restaurant>> GetAllFilteredAndSortedAndPagedAsync(RestaurantFilterDto restaurantFilter, int sortType, int page, int pageSize);
        Task<PaginatedListDto<Restaurant>> GetAllRestaurantsPaginatedAsync(int page, int pageSize);
        Task<List<RestaurantBasicDataDto>> GetAllRestaurantsAsync();
        Task<List<RestaurantBasicDataDto>> GetAllRestaurantsByOwnerIdAsync(string userId, string ownerId);
        Task<RestaurantWithMealsDto> GetRestaurantWithMealsAsync(int restaurantId);
        Task<RestaurantWithWorkingHoursAndNonWokingDaysDto> GetRestaurantWithWorkingDaysAndNonWorkingDaysAsync(string userId, int restaurantId);
        List<RestaurantSortTypeOptionDto> GetAllSortTypes();
        Task<RestaurantBasicDataDto> CreateRestaurantAsync(CreateRestaurantDto restaurantDto);
        Task<RestaurantBasicDataDto> UpdateRestaurantAsync(int resturantId, ClaimsPrincipal claimsPrincipal, UpdateRestaurantDto updateRestaurantDto);
        Task UpdateRestaurantAverageRatingAsync(int restaurantId);
        Task DeleteRestaurantAsync(int id);
        IEnumerable<string> GetDaysOfTheWeek();
        bool IsRestaurantOpen(Restaurant restaurant);
        Task<RestaurantBasicDataDto> GetRestaurantBasicDataByIdAsync(int id);
    }
}