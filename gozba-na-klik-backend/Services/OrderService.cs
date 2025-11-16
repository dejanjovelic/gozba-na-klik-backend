using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRestaurantService _restaurantService;
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        private const double deliveryPrice = 200;

        public OrderService(IOrderRepository orderRepository, IRestaurantRepository restaurantRepository, ICustomerRepository customerRepository, 
                            IRestaurantService restaurantService, IMealRepository mealRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
            _customerRepository = customerRepository;
            _restaurantService = restaurantService;
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(int ownerId)
        {
            if (ownerId == 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            return await _orderRepository.GetOrdersByOwnerIdAsync(ownerId);
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, TimeSpan orderTime)
        {
            if (orderId == 0)
                throw new BadRequestException("Invalid data.");

            if (newStatus != OrderStatus.Otkazana && newStatus != OrderStatus.Prihvacena)
                throw new ArgumentException("Status must be either Denied or Accepted", nameof(newStatus));

            await _orderRepository.UpdateOrderStatusAsync(orderId, newStatus, orderTime);
        }

        public async Task<ResponseOrderDto> CreateOrderAsync(CreateOrderDto dto)
        {
            Restaurant restaurant = await _restaurantRepository.GetRestaurantByIdAsync(dto.RestaurantId);
            if (restaurant == null) throw new NotFoundException($"Restaurant with ID: {dto.RestaurantId} not found.");
            if (_restaurantService.IsRestaurantOpen(restaurant)) throw new BadRequestException("Restaurant is closed.");

            Customer customer = await _customerRepository.GetByIdAsync(dto.CustomerId);
            if (customer == null) throw new NotFoundException($"Customer with ID: {dto.CustomerId} not found.");

            List<Meal> meals = await _mealRepository.GetMealsFromOrderAsync(dto.Items);

            double totalPrice = meals.Sum(meal =>
            {
                int quantity = dto.Items.First(i => i.MealId == meal.Id).Quantity;
                return meal.Price * quantity;
            });
            totalPrice += deliveryPrice;

            bool hasDangerousMeals = meals
            .Any(meal => meal.Allergens
            .Any(a => customer.Allergens.Any(ca => ca.Id == a.Id)));

            Address deliveryAddress = customer.Addresses.FirstOrDefault(a => a.Id == dto.DeliveryAddressId);

            Order newOrder = new Order
            {
                CustomerId = dto.CustomerId,
                RestaurantId = dto.RestaurantId,
                DeliveryAddressId = deliveryAddress.Id,
                OrderTime = DateTime.Now.TimeOfDay,
                Status = OrderStatus.NaCekanju,
                TotalPrice = totalPrice
            };

            foreach (var item in dto.Items)
            {
                newOrder.OrderItems.Add(new OrderMeal
                {
                    MealId = item.MealId,
                    Quantity = item.Quantity
                });
            }

            ResponseOrderDto responseDto = _mapper.Map<ResponseOrderDto>(await _orderRepository.CreateOrderAsync(newOrder));
            responseDto.RequiresAllergenWarn = hasDangerousMeals;

            return responseDto;
        }

        public async Task HandleOrderConfirmationAsync(int orderId, OrderStatus status)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) throw new NotFoundException($"Order with ID: {orderId} not found.");

            await _orderRepository.UpdateOrderStatusAsync(orderId, status, order.OrderTime.Value);
            return;
        }
    }
}