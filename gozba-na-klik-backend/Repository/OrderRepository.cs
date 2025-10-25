using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace gozba_na_klik_backend.Repository
{ 
    public class OrderRepository:IOrderRepository
    {
        public AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId)
        {
         
            var restaurantIds = await _context.Restaurants
                                              .Where(r => r.RestaurantOwnerId == ownerId)
                                              .Select(r => r.Id)
                                              .ToListAsync();
            return await _context.Orders
                .Where(o => restaurantIds.Contains(o.RestaurantId))
                .Select(o => new RestaurantOrderDTO
                {
                    OrderId = o.Id,
                    RestaurantName = o.Restaurant.Name,
                    CustomerName = o.Customer.Name + " " + o.Customer.Surname,
                    CustomerAddress = o.Customer.Addresses.FirstOrDefault().Street + ", " +
                                      o.Customer.Addresses.FirstOrDefault().City,
                    TotalPrice = o.OrderItems.Sum(oi => oi.Meal.Price * oi.Quantity),
                    Status = o.Status.ToString(),
                    OrderTime = o.OrderTime,
                    TotalQuantity = o.OrderItems.Sum(oi => oi.Quantity)
                })
                .ToListAsync();
        }
        public async Task EditOrderStatusAsync(int orderId, OrderStatus newStatus, TimeSpan OrderTime)
        {
            await _context.Orders.Where(o => o.Id == orderId)
                .ExecuteUpdateAsync(o => o
                .SetProperty(order => order.Status, order => newStatus)
                .SetProperty(order => order.OrderTime, order => OrderTime)
                );

        }
    }
}
