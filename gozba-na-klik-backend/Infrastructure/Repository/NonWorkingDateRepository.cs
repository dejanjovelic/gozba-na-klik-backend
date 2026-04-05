using gozba_na_klik_backend.Domain.IRepositories;
using gozba_na_klik_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Infrastructure.Repository
{
    public class NonWorkingDateRepository : INonWorkingDateRepository
    {
        private readonly AppDbContext _context;

        public NonWorkingDateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NonWorkingDate>> GetAllByRestaurantIdAsync(int id)
        {
            return await _context.NonWorkingDates
                .Where(nwd => nwd.RestaurantId == id)
                .ToListAsync();
        }

        public async Task<List<NonWorkingDate>> CreateRestaurantNonWorkingDatesAsync(List<NonWorkingDate> nonWorkingDates)
        {
            _context.NonWorkingDates.AddRange(nonWorkingDates);
            await _context.SaveChangesAsync();
            return nonWorkingDates;
        }
    }
}
