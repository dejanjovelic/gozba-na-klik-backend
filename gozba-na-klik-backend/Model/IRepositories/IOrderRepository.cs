﻿using gozba_na_klik_backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IOrderRepository
    {
        Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId);
        Task EditOrderStatusAsync(int orderId, OrderStatus newStatus, TimeSpan OrderTime); 
    }
}
