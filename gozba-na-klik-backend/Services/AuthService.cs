using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;

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

            if (user.EmailConfirmed == false)
            {
                throw new NotAuthorizedAccessException("Email is not confirmed. Check your inbox");
            }

            var token = await GenerateJwt(user);
            return token;

        }

        public async Task<AuthResponseDto> RegisterUserAsync(RegistrationDto registrationDto, string role)
        {
            var user = _mapper.Map<ApplicationUser>(registrationDto);
            user.EmailConfirmed = false;

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

            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationLink = $"{_configuration["BackendUrl"]}/api/auth/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(emailToken)}";

            string bodyMessage = $@"
            <p>Hi {user.Name},</p>

            <p>Welcome to Gozba Na Klik! To complete your registration, please activate your account by clicking the link below:</p>

            <p><a href='{confirmationLink}'>Click here to activate your account</a></p>

            <p>(This link will expire in 24 hours)</p>

            <p>If you did not create an account, please ignore this email.</p>

            <p>Thanks,<br/>
            The Gozba Na Klik Team</p>
            ";
            await _emailService.SendEmailAsync(user.Email, "Welcome to Gozba Na Klik! Please activate your account", bodyMessage);

            var token = await GenerateJwt(user);
            return new AuthResponseDto
            {
                AplicationUserId = user.Id,
                Token = token
            };
        }

        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                throw new BadRequestException("Invalid request.");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new BadRequestException($"User with ID {userId} not found.");

            var result = _userManager.ConfirmEmailAsync(user, token);
            if (result.Result.Succeeded)
            {
                return _configuration["FrontendUrl"] + "/login";
            }

            throw new BadRequestException("Invalid or expired token");
        }

        public async Task ResendConfirmationEmailAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new BadRequestException("Username is required.");

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                throw new BadRequestException("User with this username does not exist.");

            if (user.EmailConfirmed)
                throw new BadRequestException("Email is already confirmed.");

            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationLink = $"{_configuration["BackendUrl"]}/api/auth/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(emailToken)}";

            string bodyMessage = $@"
            <p>Hi {user.Name},</p>

            <p>You requested a new confirmation email. Click the link below to activate your account:</p>

            <p><a href='{confirmationLink}'>Click here to activate your account</a></p>

            <p>(This link will expire in 24 hours)</p>

            <p>If you did not request this, please ignore this email.</p>

            <p>Thanks,<br/>
            The Gozba Na Klik Team</p>
            ";

            await _emailService.SendEmailAsync(user.Email, "Resend: Activate your account", bodyMessage);
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
