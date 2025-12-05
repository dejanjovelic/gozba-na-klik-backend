using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                .ToListAsync();
        }

        public async Task<PaginatedListDto<Meal>> GetAllFilateredAndSelectedAsync(int page, int pageSize, string query, bool HideMealsWithAllergens, IEnumerable<int> combinedAllergensIds)
        {
            IQueryable<Meal> meals = _context.Meals
                .Include(meal => meal.Allergens)
                .OrderBy(meal => meal.Id);

            if (!string.IsNullOrWhiteSpace(query))
            {
                meals = FilteredMeals(meals, query);
            }

            if (HideMealsWithAllergens)
            {
                meals = meals.Where(meal => !meal.Allergens.Any(allergen => combinedAllergensIds.Contains(allergen.Id)));
            }

            int pageIndex = page - 1;
            int totalRowsCount = await meals.CountAsync();
            List<Meal> selectedMeals = await meals.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            PaginatedListDto<Meal> paginatedMeals = new PaginatedListDto<Meal>(selectedMeals, totalRowsCount, pageIndex, pageSize);

            return paginatedMeals;
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

        private static IQueryable<Meal> FilteredMeals(IQueryable<Meal> meals, string query)
        {
            string formatedQuery = query.Trim().ToLower();

            meals = meals.Where(meal => meal.MealName.ToLower().Contains(formatedQuery) || meal.Description.ToLower().Contains(formatedQuery));

            return meals;
        }
    }
}
