using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface ICreditCardRepository
    {
        Task<CreditCard> CreateAsync(CreditCard creditCard);
        Task<CreditCard> UpdateAsync(CreditCard updatedCreditCard);
        Task DeleteAsync(CreditCard creditCard);
        Task<List<CreditCard>> GetByCustomerIdAsync(string customerId);
        Task<CreditCard> GetByIdAsync(int creditCardId);
    }
}
