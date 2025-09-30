using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouriersController : ControllerBase
    {
        private readonly CourierRepository _courierRepository;

        public CouriersController(AppDbContext context)
        {
            _courierRepository = new CourierRepository(context);
        }

        //POST api/couriers
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Courier courier)
        {
            if (courier == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _courierRepository.CreateAsync(courier);
                return Ok(courier);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while creating Courier.");
            }

        }
    }
}
