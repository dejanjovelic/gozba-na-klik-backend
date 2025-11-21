using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAsync(Address address);
        Task<bool> DeleteAsync(int addressId);
        Task<List<Address>> GetByCustomerIdAsync(string customerId);
        Task<Address> GetByIdAsync(int addressId);
        Task<Address> UpdateAsync(Address updatedAddress);
    }
}