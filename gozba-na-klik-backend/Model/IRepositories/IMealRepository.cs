
using gozba_na_klik_backend.DTOs.Order;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IMealRepository
    {
        IQueryable<Meal> GetAll();
        Task<List<Meal>> GetMealsFromOrderAsync(List<OrderMealDto> orderMeals);
        Task<List<Meal>> GetAllSelectedAsync(List<int> mealsIds);
        Task<List<Meal>> GetAllMealsAsync();
    }
}
