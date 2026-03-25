using gozba_na_klik_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;

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

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RegistrationDto registrationDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            return Ok(await _courierService.CreateAsync(registrationDto));
        }

        [Authorize(Roles ="Courier")]
        [HttpPut("{courierId}/working-hours")]
        public async Task<IActionResult> UpdateWorkingHours(string courierId, [FromBody] List<WorkingHours> workingHours)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _courierService.UpdateWorkingHoursAsync(courierId, workingHours, ownerId);
            return Ok(new { Message = "Working hours updated successfully" });
        }

        [Authorize(Roles ="Courier")]
        [HttpGet("{courierId}")]
        public async Task<IActionResult> GetCourierById(string courierId)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var courier = await _courierService.GetByIdAsync(courierId, ownerId);
            return Ok(courier);
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateCourierStatus()
        {
            await _courierService.UpdateCourierStatusAsync();
            return Ok("Courier status succesfully updated");
        }

        [Authorize(Roles = "Courier")]
        [HttpGet]
        public async Task<IActionResult> GetAllCouriers()
        {
            return Ok(await _courierService.GetAllAsync());
        }
    }
}

