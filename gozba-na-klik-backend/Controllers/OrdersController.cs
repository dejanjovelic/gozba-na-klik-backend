using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "RestaurantOwner")]
        [HttpGet("orders/{ownerId}")]
        public async Task<IActionResult> GetOrdersByOwnerIdAsync(string ownerId)
        {
            string currentOwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _orderService.GetOrdersByOwnerIdAsync(ownerId, currentOwnerId));
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            return Ok(await _orderService.CreateOrderAsync(dto));
        }

        [Authorize(Roles = "Customer")]
        [HttpPatch("{id}/confirm")]
        public async Task<IActionResult> ConfirmOrder(int id)
        {
            await _orderService.HandleOrderConfirmationAsync(id, OrderStatus.Pending);
            return Ok("Order confirmed.");
        }

        [Authorize(Roles = "Customer")]
        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            await _orderService.HandleOrderConfirmationAsync(id, OrderStatus.Cancelled);
            return Ok("Order cancelled.");
        }

        [Authorize(Roles = "Customer, Courier, RestaurantOwner, Employee")]
        //PUT api/orders/{orderId=1}/status
        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatusAsync(int orderId, [FromBody] UpdateOrderDTO dto)
        {
            string authenticatedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _orderService.UpdateOrderStatusAsync(orderId, dto, authenticatedUserId));
        }

        //GET /orders/active?courierId={courierId}
        [Authorize(Roles = "Courier")]
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveOrderByCourierIdAsync([FromQuery] string courierId)
        {
            string authenticatedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _orderService.GetActiveOrderByCourierIdAsync(courierId, authenticatedUserId));
        }
        [HttpPatch("/couriers")]
        public async Task<IActionResult> AssignOrderToCourierAsync()
        {
            await _orderService.AssignOrderToCourierAsync();
            return NoContent();
        }
    }
}
