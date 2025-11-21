using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace gozba_na_klik_backend.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public AppDbContext _context;
        

        public CustomerRepository(AppDbContext context)
        {
            this._context = context;
           
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Users
                .OfType<Customer>()
                .Include(customer => customer.ApplicationUser)
                .ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(string customerId)
        {
            return await _context.Users
                .OfType<Customer>()
                .Include(customer=>customer.ApplicationUser)
                .Include(customer => customer.Allergens)
                .Include(customer => customer.Addresses)
                .FirstOrDefaultAsync(customer => customer.Id == customerId);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAllergensAsync(Customer customer, List<Allergen> allergens)
        {
            customer.Allergens.Clear();
            customer.Allergens = allergens;
            await _context.SaveChangesAsync();
            return customer;
        }

    }
}
