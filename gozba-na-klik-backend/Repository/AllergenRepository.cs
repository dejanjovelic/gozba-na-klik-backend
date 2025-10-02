using gozba_na_klik_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Repository
{
    public class AllergenRepository
    {
        private readonly AppDbContext _context;

        public AllergenRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Allergen>> GetAllAsync()
        {
            return await _context.Allergens.ToListAsync();
        }

        public async Task<List<Allergen>> GetAllSelectedAllergentsAsync(List<int> allergenIds)
        {
            return await _context.Allergens
                .Where(allergen => allergenIds.Contains(allergen.Id))
                .ToListAsync();
        }

        public async Task<Allergen> GetbyIdAsync(int allergenId)
        {
            return await _context.Allergens
                .FirstOrDefaultAsync(allergen => allergen.Id == allergenId);
        }
    }
}