using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;

namespace gozba_na_klik_backend.Repository
{
    public class OrderReviewRepository:IOrderReviewRepository
    {
        public readonly AppDbContext _context;
        public OrderReviewRepository(AppDbContext context) 
        { 
            _context = context;
        }
        public async Task CreateOrderReviewAsync(OrderReview orderReview)
        {
            await _context.AddAsync(orderReview);
            await _context.SaveChangesAsync();
        }
    }
}
