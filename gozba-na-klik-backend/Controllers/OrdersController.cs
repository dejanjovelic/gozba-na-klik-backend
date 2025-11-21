using Microsoft.AspNetCore.Mvc;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
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
            string currentOwnerId = User.FindFirstValue("sub");
            return Ok(await _orderService.GetOrdersByOwnerIdAsync(ownerId, currentOwnerId));
        }

        [Authorize(Roles = "Customer, Courier, RestaurantOwner, Employee")]
        //PUT api/orders/{orderId=1}/status
        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatusAsync(int orderId, [FromBody] UpdateOrderDTO dto)
        {
            string authenticatedUserId = User.FindFirstValue("sub");
            return Ok(await _orderService.UpdateOrderStatusAsync(orderId, dto, authenticatedUserId));
        }

        //GET /orders/active?courierId={courierId}
        [Authorize(Roles = "Courier")]
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveOrderByCourierIdAsync([FromQuery] string courierId)
        {
            string authenticatedUserId = User.FindFirstValue("sub");
            return Ok(await _orderService.GetActiveOrderByCourierIdAsync(courierId, authenticatedUserId));
        }
    }
}
