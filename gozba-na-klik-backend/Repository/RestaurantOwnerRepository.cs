using gozba_na_klik_backend.Model;

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
    }
}
