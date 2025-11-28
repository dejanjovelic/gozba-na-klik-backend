namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IInvoiceRepository
    {
        Task CreateAsync(Invoice newInvoice);
        Task<Invoice> GetByIdAsync(string invoiceId);
        Task<Invoice> GetByOrderIdAsync(int orderId);
    }
}
