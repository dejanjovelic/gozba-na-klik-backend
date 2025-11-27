using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderReview)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
