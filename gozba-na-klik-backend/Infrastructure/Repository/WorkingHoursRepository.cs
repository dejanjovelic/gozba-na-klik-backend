using gozba_na_klik_backend.Domain.IRepositories;
using gozba_na_klik_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Infrastructure.Repository
{
    public class WorkingHoursRepository : IWorkingHoursRepository
    {
        private readonly AppDbContext _context;

        public WorkingHoursRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkingHours>> GetAllByRestaurantIdAsync(int restaurantId)
        {
            return await _context.WorkingHours
                .Where(wh => wh.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task UpdateRestaurantWorkingHoursAsync(List<WorkingHours> workingHours)
        {
            _context.WorkingHours.AddRangeAsync(workingHours);
        }

        public async Task DeleteAsync(List<WorkingHours> workingHours) 
        {
             _context.WorkingHours.RemoveRange(workingHours);
        }
    }
}
