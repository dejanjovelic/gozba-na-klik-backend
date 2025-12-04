
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IMealRepository
    {
        Task<PaginatedListDto<Meal>> GetAllFilateredAndSelectedAsync(int page, int pageSize, string query, bool HideMealsWithAllergens, IEnumerable<int> combinedAllergensIds);
        Task<List<Meal>> GetMealsFromOrderAsync(List<OrderMealDto> orderMeals);
        Task<List<Meal>> GetAllSelectedAsync(List<int> mealsIds);
        Task<List<Meal>> GetAllMealsAsync();
    }
}
