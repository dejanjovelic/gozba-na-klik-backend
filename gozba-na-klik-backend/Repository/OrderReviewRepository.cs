using gozba_na_klik_backend.DTOs;
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

        public async Task<PaginatedListDto<OrderReview>> GetPagedReviewByRestaurantIdAsync(int restaurantId, int page)
        {
            IQueryable<OrderReview> reviews = _context.OrderReviews
                .Where(r => r.Order.RestaurantId == restaurantId)
                .Include(r => r.Order)
                .ThenInclude(o => o.Customer)
                .ThenInclude(c => c.ApplicationUser)
                .OrderByDescending(review => review.PostedAt);

            int pageIndex = page - 1;
            int totalRowsCount = await GetReviewCountForRestaurantAsync(restaurantId);

            List<OrderReview> selectedReviews = await reviews.Skip(pageIndex * 10).Take(10).ToListAsync();
            PaginatedListDto<OrderReview> result = new PaginatedListDto<OrderReview>(selectedReviews, totalRowsCount, pageIndex, 10);
            return result;
        }

        public async Task<int> GetReviewCountForRestaurantAsync(int restaurantId)
        {
            int reviewsCount = await _context.OrderReviews
                .Where(r => r.Order.RestaurantId == restaurantId)
                .CountAsync();

            return reviewsCount;
        }
    }
}
