using gozba_na_klik_backend.Model;
using Microsoft.EntityFrameworkCore;
namespace gozba_na_klik_backend.Repository
{
    public class CourierRepository
    {
        public AppDbContext _context;

        public CourierRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Courier> CreateAsync(Courier courier) 
        {
            _context.Add(courier);
            await _context.SaveChangesAsync();
            return courier;
        }
        public async Task<Courier?> GetByIdAsync(int courierId)
        {
            return await _context.Users
                .OfType<Courier>()
                .Include(c => c.WorkingHours)
                .FirstOrDefaultAsync(c => c.Id == courierId);
        }

        public async Task UpdateWorkingHoursAsync(int courierId, List<WorkingHours> workingHours)
        {
            var courier = await GetByIdAsync(courierId);
            if (courier == null) return;

            courier.WorkingHours.Clear();
            courier.WorkingHours = workingHours;

            await _context.SaveChangesAsync();
        }
    }
}
