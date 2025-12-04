using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using System.Security.Claims;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginData);
        Task<AuthResponseDto> RegisterUserAsync(RegistrationDto registrationDto, string role);
        Task<string> ConfirmEmailAsync(string userid, string token);
        Task ResendConfirmationEmailAsync(string username);
        Task<ProfileDTO> GetProfile(ClaimsPrincipal userPrincipal);
        Task UpdateImage(ClaimsPrincipal userPrincipal, string imageUrl);
    }
}