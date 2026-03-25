using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        public AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Address>> GetByCustomerIdAsync(string customerId)
        {
            return await _context.Addresses
                .Where(address => address.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int addressId)
        {
            return await _context.Addresses.FindAsync(addressId);
        }

        public async Task<Address> CreateAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAsync(Address updatedAddress)
        {
            _context.Addresses.Update(updatedAddress);
            await _context.SaveChangesAsync();
            return updatedAddress;
        }

        public async Task DeleteAsync(Address address)
        {
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
