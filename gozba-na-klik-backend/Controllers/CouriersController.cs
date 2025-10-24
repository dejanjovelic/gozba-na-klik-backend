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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Courier courier)
        {
            var created = await _courierService.CreateAsync(courier);
            return Ok(created);
        }

        [HttpPut("{courierId}/working-hours")]
        public async Task<IActionResult> UpdateWorkingHours(int courierId, [FromBody] List<WorkingHours> workingHours)
        {
            await _courierService.UpdateWorkingHoursAsync(courierId, workingHours);
            return Ok(new { Message = "Working hours updated successfully" });
        }

        [HttpGet("{courierId}")]
        public async Task<IActionResult> GetCourierById(int courierId)
        {
            var courier = await _courierService.GetByIdAsync(courierId);
            return Ok(courier);
        }
        [HttpPut("status")]
        public async Task<IActionResult> UpdateCourierStatus()
        {
            await _courierService.UpdateCourierStatusAsync();
            return Ok("Courier status succesfully updated");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCouriers()
        {
            return Ok(await _courierService.GetAllAsync());
        }
    }
}

