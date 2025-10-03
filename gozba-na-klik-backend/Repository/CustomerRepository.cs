using gozba_na_klik_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Repository
{
    public class CustomerRepository
    {
        public AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Customer> CreateAsync(Customer customer) 
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            return await _context.Users
                .OfType<Customer>()
                .Include(customer => customer.Allergens)
                .Include(customer => customer.Addresses)
                .FirstOrDefaultAsync(customer => customer.Id == customerId);
        }
    }
}
