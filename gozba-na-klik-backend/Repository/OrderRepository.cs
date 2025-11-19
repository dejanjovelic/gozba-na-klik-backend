using AutoMapper;
using AutoMapper.QueryableExtensions;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace gozba_na_klik_backend.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Order>> GetOrdersByOwnerIdAsync(int ownerId)
        {
            var restaurantIds = await _context.Restaurants
                .Where(r => r.RestaurantOwnerId == ownerId)
                .Select(r => r.Id)
                .ToListAsync();

            return await _context.Orders
                .Include(o => o.Customer)
                    .ThenInclude(c => c.Addresses)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Meal)
                .Where(o => restaurantIds.Contains(o.RestaurantId))
                .ToListAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime? orderTime)
        {
            await _context.Orders
                .Where(o => o.Id == orderId)
                .ExecuteUpdateAsync(o => o
                    .SetProperty(order => order.Status, order => newStatus)
                    .SetProperty(order => order.OrderTime, order => orderTime)
                );
        }
    }
}
