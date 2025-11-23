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

        public async Task<List<Order>> GetOrdersByOwnerIdAsync(string ownerId)
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
                .Where(o => restaurantIds
                .Contains(o.RestaurantId))
                .ToListAsync();
        }

        public async Task<Order> UpdateOrderStatusAsync(Order order)
        {
            await _context.SaveChangesAsync();
                return order;
        }

        public async Task<Order> GetActiveOrderByCourierIdAsync(string courierId)
        {
            return await _context.Orders
                .Include(order => order.Courier)
                .Include(order => order.Customer)
                .Include(order => order.DeliveryAddress)
                .Include(order => order.Restaurant)
                .Include(order=>order.OrderItems)
                .ThenInclude(orderItem => orderItem.Meal)                
                .FirstOrDefaultAsync(
                order => order.CourierId == courierId &&
                (order.Status == OrderStatus.PickupInProgress || order.Status == OrderStatus.DeliveryInProgress));
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            var order =  await _context.Orders
                .Include(order => order.Courier)
                .Include(order => order.Customer)
                .Include(order => order.DeliveryAddress)
                .Include(order => order.Restaurant)
                .Include(order => order.OrderItems)
                .FirstOrDefaultAsync(order => order.Id == orderId);
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
