using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IInvoiceService
    {
        Task CreateAsync(Invoice newInvoice);
        Task<Invoice> GetByIdAsync(string invoiceId, string ownerId);

    }
}
