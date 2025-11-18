using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IMealService
    {
        Task<MealFilterResponseDto> GetFilteredMealsAsync(MealFilterRequestDto mealFilterRequestDto, int page, int pageSize);
        Task<List<Meal>> GetAllSelectedAsync(List<int> mealsIds);
    }
}
