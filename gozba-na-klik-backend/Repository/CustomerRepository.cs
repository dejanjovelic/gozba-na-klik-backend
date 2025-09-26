using gozba_na_klik_backend.Model;

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
    }
}
