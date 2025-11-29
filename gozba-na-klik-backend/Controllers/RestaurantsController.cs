using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        //GET api/restaurants/paging?page=1&pageSize=5
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllRestaurantsPaginatedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            return Ok(await _restaurantService.GetAllRestaurantsPaginatedAsync(page, pageSize));
        }

        //GET api/restaurants/sortTypes
        [HttpGet("sortTypes")]
        public ActionResult GetAllSortTypes() 
        {
            return Ok(_restaurantService.GetAllSortTypes());
        }

        //GET api/restaurants/
        [HttpPost("filterAndSortAndPaging")]
        public async Task<ActionResult<List<PaginatedListDto<Restaurant>>>> GetFilteredAndSortedRestaurantPageAsync([FromBody] RestaurantFilterDto restaurantFilter, [FromQuery] int sortType = (int)RestaurantSortType.NAME_ASC, [FromQuery] int page = 1, [FromQuery] int pageSize = 5 ) 
        {
            return Ok(await _restaurantService.GetAllFilteredAndSortedAndPagedAsync(restaurantFilter, sortType, page, pageSize));
        }

        //GET api/restaurants/id/meals
        [HttpGet("{restaurantId}/meals")]
        public async Task<IActionResult> GetRestaurantWithMealsAsync(int restaurantId)
        {
            return Ok(await _restaurantService.GetRestaurantWithMealsAsync(restaurantId));
        }

    }
}
