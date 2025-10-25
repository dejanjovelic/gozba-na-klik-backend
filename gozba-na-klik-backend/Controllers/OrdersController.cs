using Microsoft.AspNetCore.Mvc;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Model;
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
 
        public async Task<IActionResult> EditOrderStatusAsync(int orderId, [FromBody] UpdateOrderDTO dto)
        {
            await _orderService.EditOrderStatusAsync(orderId, dto.NewStatus, dto.NewTime);
            return NoContent();
        }

    }
}
