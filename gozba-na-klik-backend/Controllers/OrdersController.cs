using Microsoft.AspNetCore.Mvc;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.DTOs;
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

        //GET /orders/active?courierId={courierId}
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveOrderByCourierIdAsync([FromQuery] int courierId)
        {
            return Ok(await _orderService.GetActiveOrderByCourierIdAsync(courierId));
        }
       
        //PUT api/orders/{orderId=1}status?courierId=1
        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateCourierActiveOrderStatusAsync(int orderId, [FromQuery] int courierId, [FromBody] UpdateOrderDTO updateOrder)
        {
            return Ok(await _orderService.UpdateCourierActiveOrderStatusAsync(orderId, courierId, updateOrder));
        }
    }
}
