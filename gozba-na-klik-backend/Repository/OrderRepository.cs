using AutoMapper;
using AutoMapper.QueryableExtensions;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
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
            _context.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetActiveOrderByCourierIdAsync(string courierId)
        {
            return await _context.Orders
                .Include(order => order.Courier)
                .ThenInclude(courier => courier.ApplicationUser)
                .Include(order => order.Customer)
                .ThenInclude(customer => customer.ApplicationUser)
                .Include(order => order.DeliveryAddress)
                .Include(order => order.Restaurant)
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.Meal)
                .FirstOrDefaultAsync(
                order => order.CourierId == courierId &&
                (order.Status == OrderStatus.PickupInProgress || order.Status == OrderStatus.DeliveryInProgress));
        }

        public IQueryable<Order> GetBaseOrders()
        {
            return _context.Orders
                .Include(order => order.Courier)
                .Include(order => order.Customer)
                .Include(order => order.DeliveryAddress)
                .Include(order => order.Restaurant)
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.Meal)
                .Include(order => order.OrderReview);
        }

        public async Task<List<Order>> GetActiveOrdersByCustomerIdAsync(string customerId)
        {
            return await GetBaseOrders()
                .Where(o => o.CustomerId == customerId &&
                            (o.Status == OrderStatus.PickupInProgress ||
                             o.Status == OrderStatus.DeliveryInProgress ||
                             o.Status == OrderStatus.Pending ||
                             o.Status == OrderStatus.Accepted))
                .ToListAsync();
        }


        public async Task<PaginatedListDto<Order>> GetInactiveOrdersByCustomerIdAsync(string customerId, int page, int pageSize)
        {
            var query = GetBaseOrders()
                .Where(o => o.CustomerId == customerId &&
                            (o.Status == OrderStatus.Cancelled ||
                             o.Status == OrderStatus.Delivered))
                .OrderByDescending(o => o.OrderTime);

            int totalCount = await query.CountAsync();
            int pageIndex = page - 1;

            var items = await query
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedListDto<Order>(items, totalCount, pageIndex, pageSize);
        }


        public async Task<Order> GetByIdAsync(int orderId)
        {
            var order = await _context.Orders
                .AsNoTracking()
                .Include(order => order.Courier)
                    .ThenInclude(courier => courier.ApplicationUser)
                .Include(order => order.Customer)
                    .ThenInclude(customer => customer.ApplicationUser)
                .Include(order => order.DeliveryAddress)
                .Include(order => order.Restaurant)
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Meal)
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
        public async Task AssignOrderToCourierAsync()
        {
            var orders = await _context.Orders
                .Where(o => string.IsNullOrWhiteSpace(o.CourierId) && o.Status == OrderStatus.Accepted)
                .ToListAsync();

            if(!orders.Any())
            {
                return;
            }
            var couriers = await _context.Couriers
                .Include(c => c.Orders)
                .Where(c => c.Active == true)
                .ToListAsync();

            if(!couriers.Any())
            {
                return;
            }
            foreach(var courier in couriers)
            {
                if(courier.Orders.Any(o => o.Status == OrderStatus.DeliveryInProgress || o.Status == OrderStatus.PickupInProgress))
                {
                    continue;
                }
                var nextOrder = orders.FirstOrDefault(o => o.CourierId == null);
                if(nextOrder==null)
                {
                    break;
                }
                nextOrder.CourierId= courier.Id;
                nextOrder.Status = OrderStatus.PickupInProgress;
                nextOrder.AssignedAt = DateTime.UtcNow;

                courier.Orders.Add(nextOrder);
            }
         
            await _context.SaveChangesAsync();
        }
    }
}
