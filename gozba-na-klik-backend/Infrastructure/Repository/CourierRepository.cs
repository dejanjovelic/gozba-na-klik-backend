using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace gozba_na_klik_backend.Infrastructure.Repository
{
    public class CourierRepository : ICourierRepository
    {
        public AppDbContext _context;

        public CourierRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Courier> CreateAsync(Courier courier)
        {
            _context.Couriers.Add(courier);
            await _context.SaveChangesAsync();
            return courier;
        }

        public async Task<Courier?> GetByIdAsync(string courierId)
        {
            return await _context.Couriers
                .Include(c => c.ApplicationUser)
                .Include(c => c.WorkingHours)
                .FirstOrDefaultAsync(c => c.Id == courierId);
        }
        public async Task<List<Courier>> GetAllAsync()
        {
            return await _context.Couriers
             .Include(c => c.ApplicationUser)
             .Include(c => c.WorkingHours)
             .Include(c => c.Orders)
             .ToListAsync();
        }

        public async Task UpdateWorkingHoursAsync(List<WorkingHours> workingHours)
        {
            await _context.AddRangeAsync(workingHours);
        }

        public async Task DeleteWorkingHoursAsync(List<WorkingHours> workingHours)
        {
            _context.WorkingHours.RemoveRange(workingHours);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateCourierStatusAsync(List<Courier> couriers)
        {
            await _context.SaveChangesAsync();
        }

    }
}
