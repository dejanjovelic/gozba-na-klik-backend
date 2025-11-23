using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginData);
        Task<AuthResponseDto> RegisterUserAsync(RegistrationDto registrationDto, string role);
    }
}