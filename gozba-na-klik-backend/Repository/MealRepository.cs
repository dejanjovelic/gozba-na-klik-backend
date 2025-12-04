using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Repository
{
    public class MealRepository : IMealRepository
    {
        private readonly AppDbContext _context;

        public MealRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Meal>> GetAllMealsAsync() 
        {
            return await _context.Meals
                .OrderBy(meal => meal.Id)
                .Include(meal=>meal.Allergens)
                .Include(meal=>meal.Extras)
                .Take(20)
                .ToListAsync();
        }

        public IQueryable<Meal> GetAll()
        {
            IQueryable<Meal> meals = _context.Meals
                .Include(meal => meal.Allergens)
                .OrderBy(meal => meal.Id);
            return meals;
        }

        public async Task<List<Meal>> GetMealsFromOrderAsync(List<OrderMealDto> orderMeals)
        {
            List<Meal> meals = await _context.Meals
            .Include(m => m.Allergens)
            .Where(m => orderMeals.Select(i => i.MealId).Contains(m.Id))
            .ToListAsync();
            return meals;
        }

        public async Task<List<Meal>> GetAllSelectedAsync(List<int> mealsIds)
        {
            return await _context.Meals
                .Where(meal => mealsIds.Contains(meal.Id)).ToListAsync();
        }

    }
}
