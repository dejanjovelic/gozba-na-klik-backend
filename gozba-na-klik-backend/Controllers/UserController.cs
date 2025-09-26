using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(AppDbContext context)
        {
            _userRepository = new UserRepository(context);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Dictionary<string, string> body)
        {
            var username = body["username"];
            var password = body["password"];

            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null || user.Password != password)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Role = user.Role.ToString()
            });
        }
    }
}
