using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int customerId);
        Task<Customer> UpdateCustomerAllergensAsync(Customer customer, List<Allergen> allergens);
    }
}