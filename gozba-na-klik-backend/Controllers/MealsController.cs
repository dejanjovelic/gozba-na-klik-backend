using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using gozba_na_klik_backend.Services.DTOs.MealDtos;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealsController(IMealService mealService)
        {
            _mealService = mealService;
        }
        //GET api/meals
        [Authorize(Roles ="Customer")]
        [HttpGet]
        public async Task<IActionResult> GetAllMealsAsync()
        {
            return Ok(await _mealService.GetallMealsAsync());
        }

        //POST api/meals/filter?page=1&pageSize=6
        [Authorize(Roles = "Customer")]
        [HttpPost("filter")]
        public async Task<IActionResult> GetFilteredMealsAsync([FromBody] MealFilterRequestDto mealFilterRequestDto, [FromQuery] int page = 1, [FromQuery] int pageSize = 6)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mealService.GetFilteredMealsAsync(mealFilterRequestDto, page, pageSize, ownerId));
        }
    }
}
