using gozba_na_klik_backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Servises.IServices
{
    public interface ICustomerAddresseService
    {
        Task<Address> CreateAddressAsync(int customerId, Address address);
        Task DeleteAddressAsync(int customerId, int addressId);
        Task<List<Address>> GetAddressesAsync(int customerId);
        Task<Address> UpdateAddressAsync(int customerId, int addressId, Address updatedAddress);
    }
}
