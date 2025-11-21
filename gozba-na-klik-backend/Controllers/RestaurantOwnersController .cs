using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurantOwnersController : ControllerBase
    {
        private readonly IRestaurantOwnerService _restaurantOwnerService;

        public RestaurantOwnersController(IRestaurantOwnerService restaurantOwnerService)
        {
            _restaurantOwnerService = restaurantOwnerService;
        }

        //POST api/restaurantowners
        [Authorize("Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RegistrationDto registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _restaurantOwnerService.CreateAsync(registrationDto));
        }
    }
}