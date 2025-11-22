using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IRestaurantOwnerService
    {
        Task<NewRestaurantOwnerDto> CreateAsync(RegistrationDto registrationDto);
    }
}