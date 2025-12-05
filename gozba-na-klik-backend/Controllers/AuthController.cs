using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            return Ok("Reset Password email is sent. Please check your inbox.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPassworDto resetPassworDto) 
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            
            return Ok(await _authService.ResetPasswordAsync(resetPassworDto));
        }
        
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string token)
        {
            return Redirect(await _authService.ConfirmEmailAsync(userId, token));
        }

        [HttpPost("resend-confirmation-email")]
        public async Task<IActionResult> ResendConfirmationEmail(string username)
        {
            await _authService.ResendConfirmationEmailAsync(username);
            return Ok(new { Message = "Confirmation email sent. Please check your inbox." });
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileAsync()
        {
            return Ok(await _authService.GetProfileAsync(User));
        }

        [Authorize]
        [HttpPatch("profileImage")]
        public async Task<IActionResult> UpdateImageAsync([FromBody] UpdateImageDto dto)
        {
            return Ok(await _authService.UpdateImageAsync(User, dto.ProfileImageUrl));
        }
    }
}
