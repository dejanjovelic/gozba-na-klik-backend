using gozba_na_klik_backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IOrderRepository
    {
        Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(string ownerId);
        Task<Order> UpdateOrderStatusAsync(Order order);
        Task<Order> GetActiveOrderByCourierIdAsync(string courierId);
        Task<Order> GetByIdAsync(int orderId);

        //Task<List<Order>> GetOrdersByOwnerIdAsync(int ownerId); //Promenio na string pri merge i prebacio na DTO na mojoj grani
    }
}
