using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurantOwnersController : ControllerBase
    {
        private readonly RestaurantOwnerRepository _restaurantOwnerRepository;

        public RestaurantOwnersController(AppDbContext context) 
        {
            _restaurantOwnerRepository = new RestaurantOwnerRepository(context);
        }

        //POST api/restaurantowners
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RestaurantOwner restaurantOwner)
        {
            if (restaurantOwner == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _restaurantOwnerRepository.CreateAsync(restaurantOwner);
                return Ok(restaurantOwner);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while creating Restaurant Owner.");
            }

        }

    }
}    