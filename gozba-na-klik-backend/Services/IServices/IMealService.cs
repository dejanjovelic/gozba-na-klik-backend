using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.MealDtos;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IMealService
    {
        Task<List<MealDto>> GetallMealsAsync();
        Task<MealFilterResponseDto> GetFilteredMealsAsync(MealFilterRequestDto mealFilterRequestDto, int page, int pageSize, string? ownerId);
        Task<List<Meal>> GetAllSelectedAsync(List<int> mealsIds);
    }
}
