using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.RestaurantDtos;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Security.Claims;

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

        [Authorize(Roles = "Customer")]
        //GET api/restaurants/top-rated
        [HttpGet("top-rated")]
        public async Task<IActionResult> GetTopRatedRestaurantsAsync()
        {
            return Ok(await _restaurantService.GetTopRatedRestaurantsAsync());
        }

        //GET api/restaurants/filterAndSortAndPaging
        [HttpPost("filterAndSortAndPaging")]
        public async Task<ActionResult<List<PaginatedListDto<Restaurant>>>> GetFilteredAndSortedRestaurantPageAsync([FromBody] RestaurantFilterDto restaurantFilter, [FromQuery] int sortType = (int)RestaurantSortType.NAME_ASC, [FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            return Ok(await _restaurantService.GetAllFilteredAndSortedAndPagedAsync(restaurantFilter, sortType, page, pageSize));
        }

        //GET api/restaurants/paging?page=1&pageSize=5
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllRestaurantsPaginatedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            return Ok(await _restaurantService.GetAllRestaurantsPaginatedAsync(page, pageSize));
        }

        [Authorize(Roles = "Administrator")]
        //GET api/restaurants
        [HttpGet]
        public async Task<ActionResult<List<RestaurantBasicDataDto>>> GetAllRestaurantsAsync()
        {
            return Ok(await _restaurantService.GetAllRestaurantsAsync());
        }

        [Authorize(Roles = "RestaurantOwner")]
        //GET api/restaurants/by-owner?ownerId=5
        [HttpGet("by-owner")]
        public async Task<ActionResult<List<RestaurantBasicDataDto>>> GetAllRestaurantsByOwnerIdAsync([FromQuery] string ownerId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _restaurantService.GetAllRestaurantsByOwnerIdAsync(userId, ownerId));
        }

        //GET api/restaurants/5/meals
        [HttpGet("{restaurantId}/meals")]
        public async Task<IActionResult> GetRestaurantWithMealsAsync(int restaurantId)
        {
            return Ok(await _restaurantService.GetRestaurantWithMealsAsync(restaurantId));
        }

        //GET api/restaurants/5/with-working-time
        [Authorize(Roles = "RestaurantOwner")]
        [HttpGet("{id}/with-working-time")]
        public async Task<ActionResult<RestaurantWithWorkingHoursAndNonWokingDaysDto>> GetRestaurantWithWorkingDaysAndNonWorkingDaysAsync(int id) 
        { 
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok( await _restaurantService.GetRestaurantWithWorkingDaysAndNonWorkingDaysAsync(userId, id));
        }

        //GET api/restaurants/5/basic-data
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}/basic-data")]
        public async Task<ActionResult<RestaurantBasicDataDto>> GetRestaurantBasicDataByIdAsync(int id) 
        {
            return Ok(await _restaurantService.GetRestaurantBasicDataByIdAsync(id));
        }

        //GET api/restaurants/sortTypes
        [HttpGet("sortTypes")]
        public ActionResult GetAllSortTypes()
        {
            return Ok(_restaurantService.GetAllSortTypes());
        }

        //POST api/restaurants
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<RestaurantBasicDataDto>> CreateRestaurantAsync([FromBody] CreateRestaurantDto restaurantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _restaurantService.CreateRestaurantAsync(restaurantDto));
        }

        //PUT api/restaurants/8
        [Authorize(Roles = "Administrator, RestaurantOwner")]
        [HttpPut("{id}")]
        public async Task<ActionResult<RestaurantBasicDataDto>> UpdateRestaurantAsync(int id, [FromBody] UpdateRestaurantDto updateRestaurantDto) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            return Ok(await _restaurantService.UpdateRestaurantAsync(id, User, updateRestaurantDto));
        }

        //GET /api/restaurants/days-of-the-week
        [HttpGet("days-of-the-week")]
        public ActionResult<IEnumerable<string>> GetDaysOfTheWeek() 
        {
            return Ok(_restaurantService.GetDaysOfTheWeek());
        }

        //DELETE api/restaurants/8
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurantAsync(int id)
        {
            await _restaurantService.DeleteRestaurantAsync(id);
            return NoContent();
        }
    }
}
