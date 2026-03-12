using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IRestaurantOwnerService
    {
        Task<NewRestaurantOwnerDto> CreateAsync(RegistrationDto registrationDto);
    }
}