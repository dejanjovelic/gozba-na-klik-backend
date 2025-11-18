using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("orders/{ownerId}")]
        public async Task<IActionResult> GetOrdersByOwnerIdAsync(int ownerId)
        {
            return Ok(await _orderService.GetOrdersByOwnerIdAsync(ownerId));
        }
        [HttpPut("orders/{orderId}")]
 
        public async Task<IActionResult> UpdateOrderStatusAsync(int orderId, [FromBody] UpdateOrderDTO dto)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, dto.NewStatus, dto.NewTime);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            return Ok(await _orderService.CreateOrderAsync(dto));
        }

        [HttpPatch("{id}/confirm")]
        public async Task<IActionResult> ConfirmOrder(int id)
        {
            await _orderService.HandleOrderConfirmationAsync(id, OrderStatus.NaCekanju);
            return Ok("Order confirmed.");
        }

        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            await _orderService.HandleOrderConfirmationAsync(id, OrderStatus.Otkazana);
            return Ok("Order cancelled.");
        }

    }
}
