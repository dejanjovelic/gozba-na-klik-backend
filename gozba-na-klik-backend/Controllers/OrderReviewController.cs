using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReviewController : ControllerBase
    {
        private readonly IOrderReviewService _orderReviewService;

        public OrderReviewController(IOrderReviewService orderReviewService)
        {
            _orderReviewService = orderReviewService;
        }

        [HttpPost("/orderReview")]
        public async Task<IActionResult> CreateReviewAsync([FromBody] OrderReview orderReview)
        {
            await _orderReviewService.CreateOrderReviewAsync(orderReview);
            return NoContent();
        }
    }
}
