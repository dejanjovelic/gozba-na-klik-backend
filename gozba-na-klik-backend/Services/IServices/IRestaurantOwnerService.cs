using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;
using gozba_na_klik_backend.Services.DTOs.RestaurantOwnerDtos;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IRestaurantOwnerService
    {
        Task<CreateRestaurantOwnerDto> CreateAsync(RegistrationDto registrationDto);
        Task<List<RestaurantOwnerShortResponseDto>> GetAllAsync();
    }
}