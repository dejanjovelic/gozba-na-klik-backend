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

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, DateTime orderTime)
        {
            if (orderId == 0)
                throw new BadRequestException("Invalid data.");

            if (newStatus != OrderStatus.Otkazana && newStatus != OrderStatus.Prihvacena)
                throw new ArgumentException("Status must be either Denied or Accepted", nameof(newStatus));

            await _orderRepository.UpdateOrderStatusAsync(orderId, newStatus, orderTime);
        }

        public async Task<ResponseOrderDto> CreateOrderAsync(CreateOrderDto dto)
        {
            Restaurant restaurant = await ValidateRestaurantAsync(dto.RestaurantId);

            Customer customer = await ValidateCustomerAsync(dto.CustomerId);

            List<Meal> meals = await _mealRepository.GetMealsFromOrderAsync(dto.Items);

            double totalPrice = CalculateTotalPrice(dto, meals);

            bool hasDangerousMeals = meals
            .Any(meal => meal.Allergens
            .Any(a => customer.Allergens.Any(ca => ca.Id == a.Id)));

            Order newOrder = CreateOrderEntity(customer, dto, totalPrice);

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

        private async Task<Restaurant> ValidateRestaurantAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(restaurantId);
            if (restaurant == null) throw new NotFoundException($"Restaurant with ID {restaurantId} not found.");

            if (!_restaurantService.IsRestaurantOpen(restaurant)) 
                throw new BadRequestException("Restaurant is closed.");

            return restaurant;
        }

        private async Task<Customer> ValidateCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new NotFoundException($"Customer with ID: {customerId} not found.");

            return customer;
        }

        private double CalculateTotalPrice(CreateOrderDto dto, List<Meal> meals)
        {
            double totalPrice = meals.Sum(meal =>
            {
                int quantity = dto.Items.First(i => i.MealId == meal.Id).Quantity;
                return meal.Price * quantity;
            });
            totalPrice += deliveryPrice;
            return totalPrice;
        }

        private Order CreateOrderEntity(Customer customer,CreateOrderDto dto, double totalPrice)
        {
            var deliveryAddress = customer.Addresses
            .FirstOrDefault(a => a.Id == dto.DeliveryAddressId);

            if (deliveryAddress == null)
                throw new BadRequestException("Invalid delivery address.");

            return new Order
            {
                CustomerId = dto.CustomerId,
                RestaurantId = dto.RestaurantId,
                DeliveryAddressId = dto.DeliveryAddressId,
                OrderTime = DateTime.UtcNow,
                Status = OrderStatus.NaCekanju,
                TotalPrice = totalPrice,
                OrderItems = dto.Items.Select(item => new OrderMeal
                {
                    MealId = item.MealId,
                    Quantity = item.Quantity
                }).ToList()
            };
        }
    }
}