using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _authService.LoginAsync(loginData));
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _authService.ForgotPasswordAsync(forgotPasswordDto);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPassworDto resetPassworDto) 
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            
            return Ok(await _authService.ResetPasswordAsync(resetPassworDto));
        }
    }
}
