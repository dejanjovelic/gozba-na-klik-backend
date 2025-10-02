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

        public async Task<List<Customer>> GetAllAsync() 
        {
            return await _context.Users
                .OfType<Customer>().ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int customerId) 
        {
            return await _context.Users
                .OfType<Customer>()
                .FirstOrDefaultAsync(customer=>customer.Id==customerId);
        }

        public async Task<Customer> CreateAsync(Customer customer) 
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAllergensAsync(Customer customer, List<Allergen> allergens) 
        {
            customer.Allergens = allergens;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
