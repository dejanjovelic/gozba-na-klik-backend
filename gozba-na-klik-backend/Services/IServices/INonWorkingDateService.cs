using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.NonWorkingDateDtos;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface INonWorkingDateService
    {
        Task<List<NonWorkingDateResponseDto>> GetAllByRestaurantIdAsync(int RestaurantId);
        Task CreateRestaurantNonWorkingDatesAsync(Restaurant restaurant, List<CreateNonWorkingDateDto> createNonWorkingDatesDtos);
        Task DeleteRestaurantNonWorkingDatesAsync(Restaurant restaurant, List<CreateNonWorkingDateDto> createNonWorkingDateDtos); 

    }
}