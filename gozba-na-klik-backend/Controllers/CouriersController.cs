using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Services;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouriersController : ControllerBase
    {
        private readonly ICourierService _courierService;

        public CouriersController(ICourierService courierService)
        {
            _courierService = courierService;
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
                await _courierService.CreateAsync(courier);
                return Ok(courier);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while creating Courier.");
            }

        }
        [HttpPut("{courierId}/working-hours")]
        public async Task<IActionResult> UpdateWorkingHours(int courierId, [FromBody] List<WorkingHours> workingHours)
        {
            if (courierId <= 0)
            {
                return BadRequest(new { Message = "Invalid courier ID" });
            }
            try
            {
                var existingCourier = await _courierService.GetByIdAsync(courierId);
                if (existingCourier == null)
                {
                    return NotFound(new { Message = "Courier not found" });
                }

                await _courierService.UpdateWorkingHoursAsync(existingCourier, workingHours);
                return Ok(new { Message = "Working hours updated successfully" });
            }
            catch (Exception)
            {
                return Problem("An error occurred while updating working hours");
            }
        }
        
        
        [HttpGet("{courierId}")]
        public async Task<IActionResult> GetCourierById(int courierId)
        {
            if (courierId <= 0)
            {
                return BadRequest(new { Message = "Invalid courier ID" });
            }
            try
            {
                var courier = await _courierService.GetByIdAsync(courierId);
                if (courier == null)
                    return NotFound(new { Message = "Courier not found" });

                return Ok(new
                {
                    Id = courier.Id,
                    Username = courier.Username,
                    Name = courier.Name,
                    Surname = courier.Surname,
                    WorkingHours = courier.WorkingHours.Select(wh => new
                    {
                        DayOfTheWeek = wh.DayOfTheWeek.ToString(),
                        StartingTime = wh.StartingTime.ToString(@"hh\:mm\:ss"),
                        EndingTime = wh.EndingTime.ToString(@"hh\:mm\:ss")
                    })
                });
            }
            catch (Exception)
            {
                return Problem("An error occurred while getting courier by his Id");
            }
        }
    }
}
