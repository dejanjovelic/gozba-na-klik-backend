using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using MongoDB.Driver;

namespace gozba_na_klik_backend.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IMongoCollection<Invoice> _invoicesCollection;

        public InvoiceRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _invoicesCollection = database.GetCollection<Invoice>(configuration["MongoDB:CollectionName"]);
        }

        public async Task<Invoice> GetByIdAsync(string invoiceId)
        {
            return await _invoicesCollection
                .Find(invoice => invoice.Id == invoiceId).FirstOrDefaultAsync();
        }

        public async Task<Invoice> GetByOrderIdAsync(int orderId)
        {
            return await _invoicesCollection
                .Find(invoice => invoice.OrderId == orderId).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Invoice newInvoice)
        {
            await _invoicesCollection.InsertOneAsync(newInvoice);
        }
    }
}
