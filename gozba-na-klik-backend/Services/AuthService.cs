using AutoMapper;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using gozba_na_klik_backend.Services.IServices;

namespace gozba_na_klik_backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService
            (
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginDto loginData)
        {
            var user = await _userManager.FindByNameAsync(loginData.Username);
            if (user == null)
            {
                throw new BadRequestException("Invalid credentials.");
            }

            var passwordMatch = await _userManager.CheckPasswordAsync(user, loginData.Password);
            if (!passwordMatch)
            {
                throw new BadRequestException("Invalid credentials.");
            }

            var token = await GenerateJwt(user);
            return token;

        }

        public async Task<AuthResponseDto> RegisterUserAsync(RegistrationDto registrationDto, string role)
        {
            var user = _mapper.Map<ApplicationUser>(registrationDto);
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded)
            {
                string errorMessage = string.Join(", ", result.Errors.Select(error => error.Description));
                throw new BadRequestException(errorMessage);
            }

            if (!await _userManager.IsInRoleAsync(user, role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            var token = await GenerateJwt(user);
            return new AuthResponseDto
            {
                AplicationUserId = user.Id,
                Token = token
            };
        }


        private async Task<string> GenerateJwt(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim("username", user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim("role", role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
