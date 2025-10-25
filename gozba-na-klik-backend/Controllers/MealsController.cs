using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gozba_na_klik_backend.Exceptions;

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


        //POST api/meals/filter
        [HttpPost("filter")]
        public async Task<IActionResult> GetFilteredMealsAsync([FromBody] MealFilterRequestDto mealFilterRequestDto, [FromQuery] int page = 1, [FromQuery] int pageSize = 6)
        {
            return Ok(await _mealService.GetFilteredMealsAsync(mealFilterRequestDto, page, pageSize));
        }
    }
}
