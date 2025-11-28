using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Services.IServices;
using MongoDB.Driver;
using gozba_na_klik_backend.Model.IRepositories;

namespace gozba_na_klik_backend.Services
{
    public class InvoiceService : IInvoiceService
    {
        public readonly IInvoiceRepository _invoiceRepository;
        

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> GetByIdAsync(string invoiceId, string ownerId)
        {
            if (string.IsNullOrEmpty(invoiceId))
            {
                throw new BadRequestException("Invalid invoice Id.");
            }

            Invoice invoice = await _invoiceRepository.GetByIdAsync(invoiceId);

            if (invoice.CustomerId != ownerId)
            {
                throw new ForbiddenException($"Customer");
            }

            return invoice;
        }


        public async Task CreateAsync(Invoice newInvoice)
        {
            if (newInvoice == null)
            {
                throw new BadRequestException("Invalid invoice data.");
            }
            Invoice existingInvoice = await _invoiceRepository.GetByOrderIdAsync(newInvoice.OrderId);
            
            if (existingInvoice != null) 
            {
                throw new ConflictException("Invoice is alredy created.");
            }

            await _invoiceRepository.CreateAsync(newInvoice);
        }

    }
}
