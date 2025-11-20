using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            this._mapper = mapper;
        }

        public async Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId)
        {
            if (ownerId == 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            var orders = await _orderRepository.GetOrdersByOwnerIdAsync(ownerId);
            return _mapper.Map<List<RestaurantOrderDTO>>(orders);
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime? orderTime)
        {
            if (orderId == 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            if (newStatus != OrderStatus.Canceled && newStatus != OrderStatus.Accepted)
            {
                throw new ArgumentException("Status must be either Denied or Accepted", nameof(newStatus));
            }

            await _orderRepository.UpdateOrderStatusAsync(orderId, newStatus, orderTime);
        }
        public async Task AssignOrderToCourierAsync()
        {
           await _orderRepository.AssignOrderToCourierAsync();
        }
    }
 }