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
        private readonly IEmailService _emailService;

        public AuthService
            (
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IMapper mapper,
            IEmailService emailService
            )
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _emailService = emailService;
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

        public async Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto) 
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null) 
            {
                throw new NotFoundException($"User with {forgotPasswordDto.Email} not found.");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Uri.EscapeDataString(token);

            var resetUrl = $"{forgotPasswordDto.ResetUrlBase}?email={user.Email}&token={encodedToken}";

            string bodyMessage = $@"
           <p>Hi {user.Name},</p>
            <p>We received a request to reset your password.</p>
            <p>If you initiated this request, please click the link below to set a new password:</p>
            <p>👉 <a href='{resetUrl}'>Click here to reset password</a></p>
            <p>(This link will remain active for the next 60 minutes.)</p>
            <p>If you did not request a password reset, please ignore this email. Your current password will remain unchanged.</p>
            <p>Thanks,<br/>
            The Gozba Na Klik Team</p>";

            await _emailService.SendEmailAsync(user.Email, "Reset Password", bodyMessage);
        }

        public async Task<string> ResetPasswordAsync(ResetPassworDto resetPassworDto) 
        {
            var user = await _userManager.FindByEmailAsync(resetPassworDto.Email);
            if (user == null) 
            { 
                throw new NotFoundException($"User with {resetPassworDto.Email} not found.");
            };

            var decodedToken = Uri.UnescapeDataString(resetPassworDto.Token);
            var result = await _userManager.ResetPasswordAsync(user, decodedToken, resetPassworDto.NewPassword);

            if (!result.Succeeded) 
            {
                throw new BadRequestException($"{result.Errors}");
            }
            string bodyMessage = $@"
           <h2>Your password was successfully changed</h2>
            <p>The password for your GozbaNaKlik.com account {user.Email} was changed.</p>
            <p>Thanks,<br/>
            The Gozba Na Klik Team</p>";
            await _emailService.SendEmailAsync(user.Email, "Passsword reset confirmation", bodyMessage);
            return _configuration["FrontendUrl"] + "/login";
        }


        private async Task<string> GenerateJwt(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim("username", user.UserName),
                new Claim("name", user.Name),
                new Claim("surname", user.Surname),
                new Claim("id", user.Id),
                new Claim("profileImageUrl", user.ProfileImageUrl ?? string.Empty),
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
