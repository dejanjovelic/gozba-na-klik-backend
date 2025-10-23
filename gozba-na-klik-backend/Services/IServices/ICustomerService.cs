using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface ICustomerService
    {
        Task<Address> CreateAddressAsync(int customerId, Address address);
        Task<Customer> CreateAsync(Customer customer);
        Task DeleteAddressAsync(int customerId, int addressId);
        Task<List<Address>> GetAddressesAsync(int customerId);
        Task<List<Allergen>> GetAllCustomerAllergensAsync(int customerId);
        Task<Customer> GetByIdAsync(int customerId);
        Task<Address> UpdateAddressAsync(int customerId, int addressId, Address updatedAddress);
        Task<Customer> UpdateCustomerAllergensAsync(int customerId, List<int> allergenIds);
    }
}