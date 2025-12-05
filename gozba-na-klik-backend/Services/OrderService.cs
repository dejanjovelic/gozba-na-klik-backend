using AutoMapper;
using AutoMapper.QueryableExtensions;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        private readonly IMealService _mealService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInvoiceService _invoiceService;
        private readonly IPdfGeneratorService _pdfGeneratorService;
        private readonly IInvoiceRepository _invoiceRepository;
        private const double deliveryPrice = 2;

        public OrderService(
            IOrderRepository orderRepository,
            IRestaurantRepository restaurantRepository,
            ICustomerRepository customerRepository,
            IRestaurantService restaurantService,
            IMealRepository mealRepository,
            IMapper mapper,
            IMealService mealService,
            IHttpContextAccessor httpContextAccessor,
            IInvoiceService invoiceService,
            IPdfGeneratorService pdfGeneratorService,
            IInvoiceRepository invoiceRepository

            )
        {
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
            _customerRepository = customerRepository;
            _restaurantService = restaurantService;
            _mealRepository = mealRepository;
            _mapper = mapper;
            _mealService = mealService;
            _httpContextAccessor = httpContextAccessor;
            _invoiceService = invoiceService;
            _pdfGeneratorService = pdfGeneratorService;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<List<RestaurantOrderDTO>> GetOrdersByOwnerIdAsync(string ownerId, string? currentOwnerId)
        {
            if (ownerId != currentOwnerId)
            {
                throw new ForbiddenException($"Restaurant owner with Id: {ownerId} do not have permission to perform this action.");
            }

            if (string.IsNullOrWhiteSpace(ownerId))
            {
                throw new BadRequestException("Invalid data.");
            }

            var orders = await _orderRepository.GetOrdersByOwnerIdAsync(ownerId);
            return _mapper.Map<List<RestaurantOrderDTO>>(orders);
        }

        public async Task<List<CustomerOrderResponseDto>> GetActiveOrdersByCustomerIdAsync(ClaimsPrincipal userPrincipal)
        {
            var customerId = userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (customerId == null) throw new BadRequestException("Token is invalid");

            var orders = await _orderRepository.GetActiveOrdersByCustomerIdAsync(customerId);

            return _mapper.Map<List<CustomerOrderResponseDto>>(orders);
        }


        public async Task<PaginatedListDto<CustomerOrderResponseDto>> GetInactiveOrdersByCustomerIdAsync(
            ClaimsPrincipal userPrincipal, int page, int pageSize)
        {
            var customerId = userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (customerId == null) throw new BadRequestException("Token is invalid");

            if (page < 1)
                throw new BadRequestException("Page must be greater than 0.");

            if (pageSize < 1 || pageSize > 18)
                throw new BadRequestException("Page size must be between 1 and 18.");

            var paginatedOrders = await _orderRepository
                .GetInactiveOrdersByCustomerIdAsync(customerId, page, pageSize);

            return new PaginatedListDto<CustomerOrderResponseDto>()
            {
                Items = _mapper.Map<List<CustomerOrderResponseDto>>(paginatedOrders.Items),
                TotalRowsCount = paginatedOrders.TotalRowsCount,
                PageIndex = paginatedOrders.PageIndex,
                TotalPages = paginatedOrders.TotalPages,
                HasNextPage = paginatedOrders.HasNextPage,
                HasPreviousPage = paginatedOrders.HasPreviousPage
            };

        }



        public async Task<CourierOrderDto> UpdateOrderStatusAsync(int orderId, UpdateOrderDTO dto, string? authenticatedUserId)
        {
            var roles = GetUserRoles();

            if (orderId == 0)
            {
                throw new BadRequestException("Invalid data.");
            }

            Order order = await _orderRepository.GetByIdAsync(orderId);

            ValidateActiveOrderUpdateData(orderId, dto.NewStatus, authenticatedUserId, order, roles);

            order.Status = dto.NewStatus;

            if (roles.Contains("RestaurantOwner"))
            {
                if (dto.PickupReadyIn > 0)
                {
                    order.PickupReadyAt = dto.NewTime.AddMinutes(dto.PickupReadyIn); 
                }
            }
            else if (roles.Contains("Courier"))
            {
                if (dto.NewStatus.ToString().Trim().ToLower() == "deliveryinprogress")
                {
                    order.DeliveryStartedAt = dto.NewTime;
                }
                else if (dto.NewStatus.ToString().Trim().ToLower() == "delivered")
                {
                    order.DeliveredAt = dto.NewTime;
                }
            }

            Order updatedOrder = await _orderRepository.UpdateOrderStatusAsync(order);

            if (updatedOrder.Status.ToString().Trim().ToLower() == "delivered")
            {
                Invoice invoice = _mapper.Map<Invoice>(order);
                await _invoiceService.CreateAsync(invoice);
            }

            return _mapper.Map<CourierOrderDto>(updatedOrder);
        }

        private List<string> GetUserRoles()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                return new List<string>();
            }
            var roles = user.Claims
                            .Where(c => c.Type == ClaimTypes.Role)
                            .Select(c => c.Value)
                            .ToList();
            return roles;
        }

        private static void ValidateActiveOrderUpdateData(int orderId, OrderStatus newStatus, string? authenticatedUserId, Order order, List<string> roles)
        {
            if (order == null)
            {
                throw new NotFoundException($"Order with Id:{orderId} not found.");
            }

            if (roles.Contains("RestaurantOwner"))
            {
                if (order.Restaurant.RestaurantOwnerId != authenticatedUserId)
                {
                    throw new ForbiddenException($"Restaurant owner with Id: {authenticatedUserId} do not have permission to access this order.");
                }

                if (order.Status != OrderStatus.Pending)
                {
                    throw new ForbiddenException("Restaurant owner can only modify orders that are in 'Pending' status.");
                }

                if (newStatus != OrderStatus.Cancelled && newStatus != OrderStatus.Accepted)
                {
                    throw new ArgumentException("Status must be either Denied or Accepted", nameof(newStatus));
                }
            }

            if (roles.Contains("Courier"))
            {
                if (order.CourierId != authenticatedUserId)
                {
                    throw new ForbiddenException($"Courier with Id: {authenticatedUserId} is not authorized to update order with ID: {orderId}.");
                }

                if (order.Status != OrderStatus.PickupInProgress && order.Status != OrderStatus.DeliveryInProgress)
                {
                    throw new BadRequestException($"Courier can only modify orders that are in 'Pickup in progress' or  'Delivery In Progress' status.");
                }

                if (newStatus != OrderStatus.DeliveryInProgress && newStatus != OrderStatus.Delivered)
                {
                    throw new BadRequestException("Status of order must be either 'Delivery in progress'  or 'Delivered'.");
                }
            }

            if (roles.Contains("Customer"))
            {
                if (order.CustomerId != authenticatedUserId)
                {
                    throw new ForbiddenException($"Customer with Id: {authenticatedUserId} is not authorized to update order with ID: {orderId}.");
                }

                if (order.Status != OrderStatus.Pending)
                {
                    throw new BadRequestException($"Customer can only modify orders that are in 'Pending' status.");
                }

                if (newStatus != OrderStatus.Cancelled)
                {
                    throw new BadRequestException("Customer can change status of order only in 'Canceled'.");
                }
            }
        }

        public async Task<CourierOrderDto> GetActiveOrderByCourierIdAsync(string courierId, string? authenticatedUserId)
        {
            if (string.IsNullOrWhiteSpace(courierId))
            {
                throw new BadRequestException("Invalid courier data.");
            }
            if (courierId != authenticatedUserId)
            {
                throw new ForbiddenException($"You are not allowed to access another courier's orders.");
            }

            Order order = await _orderRepository.GetActiveOrderByCourierIdAsync(courierId);

            if (order == null)
            {
                throw new NotFoundException("You currently have no assigned orders.");
            }

            List<CourierOrderMealDto> courierOrderMeals = order.OrderItems.Select(_mapper.Map<CourierOrderMealDto>).ToList();

            CourierOrderDto courierOrderDto = _mapper.Map<CourierOrderDto>(order);
            courierOrderDto.OrderItems = courierOrderMeals;
            return courierOrderDto;
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

            Order newOrder = CreateOrderEntity(meals, customer, dto, totalPrice);

            Order createdOrder = await _orderRepository.CreateOrderAsync(newOrder);

            ResponseOrderDto responseDto = _mapper.Map<ResponseOrderDto>(createdOrder);
            responseDto.RequiresAllergenWarn = hasDangerousMeals;

            return responseDto;
        }

        public async Task HandleOrderConfirmationAsync(int orderId, OrderStatus status)
        {
            Order order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) throw new NotFoundException($"Order with ID: {orderId} not found.");

            order.Status = status;

            await _orderRepository.UpdateOrderStatusAsync(order);
            return;
        }

        private async Task<Restaurant> ValidateRestaurantAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(restaurantId);
            if (restaurant == null) throw new NotFoundException($"Restaurant with ID {restaurantId} not found.");

            //Trebaju biti definisani workinghours da bi ovaj if radio
            if (_restaurantService.IsRestaurantOpen(restaurant))
                throw new BadRequestException("Restaurant is closed.");

            return restaurant;
        }

        private async Task<Customer> ValidateCustomerAsync(string customerId)
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

        private Order CreateOrderEntity(List<Meal> meals, Customer customer, CreateOrderDto dto, double totalPrice)
        {
            var deliveryAddress = customer.Addresses
            .FirstOrDefault(a => a.Id == dto.DeliveryAddressId);

            if (deliveryAddress == null)
                throw new BadRequestException("Invalid delivery address.");

            if (meals.Any(m => m.RestaurantId != dto.RestaurantId))
                throw new BadHttpRequestException("Meals do not belong to restaurant");

            return new Order
            {
                CustomerId = dto.CustomerId,
                RestaurantId = dto.RestaurantId,
                DeliveryAddressId = dto.DeliveryAddressId,
                OrderTime = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                TotalPrice = totalPrice,
                OrderItems = dto.Items.Select(item => new OrderMeal
                {
                    MealId = item.MealId,
                    Quantity = item.Quantity
                }).ToList()
            };
        }


        public async Task<byte[]> GetPdfInvoiceForOrderAsync(int orderId, string? customerId)
        {
            if (orderId == null)
            {
                throw new BadRequestException("Invalid order Id data.");
            }

            Order order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null)
            {
                throw new NotFoundException($"Order with Id: {orderId} not found");
            }

            if (order.CustomerId != customerId)
            {
                throw new ForbiddenException($"Order with Id: {orderId}  is not isued to Customer with Id: {customerId}.");
            }

            Invoice invoice = await _invoiceRepository.GetByOrderIdAsync(orderId);

            if (invoice == null)
            {
                throw new BadRequestException($"Invoice for order with Id: {orderId} not found.");
            }

            return _pdfGeneratorService.GenerateInvoicePdf(invoice);
        }

        public async Task AssignOrderToCourierAsync()
        {
           await _orderRepository.AssignOrderToCourierAsync();
        }
    }
 }