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

        public async Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId)
        {
            var restaurantIds = await _context.Restaurants
                .Where(r => r.RestaurantOwnerId == ownerId)
                .Select(r => r.Id)
                .ToListAsync();

            return await _context.Orders
                .Where(o => restaurantIds.Contains(o.RestaurantId))
                .ProjectTo<RestaurantOrderDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, TimeSpan orderTime)
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
