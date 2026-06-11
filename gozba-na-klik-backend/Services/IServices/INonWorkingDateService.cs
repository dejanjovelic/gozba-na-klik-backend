using gozba_na_klik_backend.Services.DTOs.NonWorkingDateDtos;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface INonWorkingDateService
    {
        Task<List<NonWorkingDateResponseDto>> CreateRestaurantNonWorkingDatesAsync(int restaurantId, List<CreateNonWorkingDateDto> createNonWorkingDatesDtos);
        Task<List<NonWorkingDateResponseDto>> GetAllByRestaurantIdAsync(int RestaurantId);
    }
}