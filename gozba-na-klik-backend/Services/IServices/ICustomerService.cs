using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface ICustomerService
    {
        Task<Address> CreateAddressAsync(string customerId, Address address, string? ownerId);
        Task<string> CreateAsync(RegistrationDto registrationDto);
        Task DeleteAddressAsync(string customerId, int addressId, string? ownerId);
        Task<List<Address>> GetAddressesAsync(string customerId, string? ownerId);
        Task<List<Allergen>> GetAllCustomerAllergensAsync(string customerId, string? ownerId);
        Task<Customer> GetByIdAsync(string customerId, string? ownerId);
        Task<Address> UpdateAddressAsync(string customerId, int addressId, Address updatedAddress, string? ownerId);
        Task<Customer> UpdateCustomerAllergensAsync(string customerId, List<int> allergenIds, string? ownerId);
    }
}