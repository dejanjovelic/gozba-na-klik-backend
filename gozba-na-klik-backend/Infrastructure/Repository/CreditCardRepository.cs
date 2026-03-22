using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Infrastructure.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        public AppDbContext _context;

        public CreditCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CreditCard>> GetByCustomerIdAsync(string customerId)
        {
            return await _context.Set<CreditCard>()
                .Where(cc => cc.OwnerId == customerId)
                .ToListAsync();
        }

        public async Task<CreditCard> GetByIdAsync(int creditCardId)
        {
            return await _context.Set<CreditCard>().FindAsync(creditCardId);
        }

        public async Task<CreditCard> CreateAsync(CreditCard creditCard)
        {
            _context.Set<CreditCard>().Add(creditCard);
            await _context.SaveChangesAsync();
            return creditCard;
        }

        public async Task<CreditCard> UpdateAsync(CreditCard updatedCreditCard)
        {
            _context.Set<CreditCard>().Update(updatedCreditCard);
            await _context.SaveChangesAsync();
            return updatedCreditCard;
        }

        public async Task DeleteAsync(CreditCard creditCard)
        {
            _context.Set<CreditCard>().Remove(creditCard);
            await _context.SaveChangesAsync();
        }
    }
}
