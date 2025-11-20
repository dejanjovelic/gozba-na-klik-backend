using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace gozba_na_klik_backend.Repository
{
    public class CourierRepository:ICourierRepository
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
        public async Task<List<Courier>> GetAllAsync()
        {
            return await _context.Couriers
              .Include(c => c.WorkingHours)
              .Include(c => c.Orders)
              .ToListAsync();
        }
        public async Task UpdateWorkingHoursAsync(Courier courier, List<WorkingHours> workingHours)
        {
            if (courier == null) return;

            courier.WorkingHours.Clear();
            courier.WorkingHours = workingHours;

            await _context.SaveChangesAsync();
        }
        public async Task UpdateCourierStatusAsync()
        {
            var now = DateTime.Now;
            var currentDay = now.DayOfWeek;
            var currentTime = now.TimeOfDay;
            List<Courier> Couriers = await GetAllAsync();
            foreach (var courier in Couriers)
            {
                // Check if any of today's working hours include the current time
                bool isWorkingNow = courier.WorkingHours?
                    .Any(wh => wh.DayOfTheWeek == currentDay &&
                               currentTime >= wh.StartingTime &&
                               currentTime <= wh.EndingTime)
                    ?? false;

                courier.active = isWorkingNow;
            }

            await _context.SaveChangesAsync();
        }
    }
}
