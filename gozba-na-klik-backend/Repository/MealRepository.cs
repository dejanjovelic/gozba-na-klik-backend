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

        public IQueryable<Meal> GetAll()
        {
            IQueryable<Meal> meals = _context.Meals
                .Include(meal => meal.Allergens)
                .OrderBy(meal => meal.Id);
            return meals;
        }

    }
}
