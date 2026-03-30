using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface ICustomerService
    {
        List<string> GetCardBrands();
        Task<List<CreditCardResponseDto>> GetCreditCardsAsync(string customerId, string? ownerId);
        Task<CreditCardResponseDto> CreateCreditCardAsync(string customerId, NewCreditCardDto newCreditCard, string? ownerId);
        Task<CreditCardResponseDto> UpdateCreditCardAsync(string customerId, int creditCardId, NewCreditCardDto updatedCreditCard, string? ownerId);
        Task DeleteCreditCardAsync(string customerId, int creditCardId, string? ownerId);
        Task<Address> CreateAddressAsync(string customerId, NewAddressDto updatedAddress, string? ownerId);
        Task<string> CreateAsync(RegistrationDto registrationDto);
        Task DeleteAddressAsync(string customerId, int addressId, string? ownerId);
        Task<List<Address>> GetAddressesAsync(string customerId, string? ownerId);
        Task<List<Allergen>> GetAllCustomerAllergensAsync(string customerId, string? ownerId);
        Task<Customer> GetByIdAsync(string customerId, string? ownerId);
        Task<Address> UpdateAddressAsync(string customerId, int addressId, NewAddressDto updatedAddress, string? ownerId);
        Task<Customer> UpdateCustomerAllergensAsync(string customerId, List<int> allergenIds, string? ownerId);
    }
}