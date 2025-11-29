using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReviewController : ControllerBase
    {
        private readonly IOrderReviewService _orderReviewService;
        private readonly IMapper _mapper;
        public OrderReviewController(IOrderReviewService orderReviewService, IMapper mapper)
        {
            _orderReviewService = orderReviewService;
            _mapper = mapper;
        }
  
        [HttpPost]       
        public async Task<IActionResult> CreateReviewAsync([FromBody] CreateOrderReviewDTO dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                await _orderReviewService.CreateOrderReviewAsync(dto);
                return NoContent();
        }
    }
}
