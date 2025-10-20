using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface ICustomerAllergenService
    {
        Task<List<Allergen>> GetAllCustomerAllergensAsync(int customerId);
        Task<Customer> UpdateCustomerAllergensAsync(int customerId, List<int> allergenIds);
    }
}
