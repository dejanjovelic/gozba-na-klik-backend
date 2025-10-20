using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Dictionary<string, string> body)
        {
            var username = body["username"];
            var password = body["password"];

            var user = await _userService.LoginAsync(username, password);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
    }
}
