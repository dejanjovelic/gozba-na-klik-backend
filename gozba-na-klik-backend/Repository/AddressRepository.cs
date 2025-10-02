using gozba_na_klik_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Repository
{
    public class AddressRepository
    {
        public AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Address>> GetAddressesByCustomerIdAsync(int customerId)
        {
            return await _context.Addresses
                .Where(address => address.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
