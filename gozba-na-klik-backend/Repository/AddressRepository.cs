using gozba_na_klik_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Repository
{
    public class AddressRepository
    {
        public AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Address>> GetByCustomerIdAsync(int customerId)
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

        public async Task<bool> DeleteAsync(int addressId)
        {
            Address address = await _context.Addresses.FindAsync(addressId);

            if (address == null)
            {
                return false;
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
