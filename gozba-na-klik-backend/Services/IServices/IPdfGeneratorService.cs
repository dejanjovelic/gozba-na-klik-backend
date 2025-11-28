using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IPdfGeneratorService
    {
        byte[] GenerateInvoicePdf(Invoice invoice);
    }
}