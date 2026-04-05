using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.WorkingHoursDtos;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IWorkingHoursService
    {
        Task<List<WorkingHoursDto>> GetAllByRestaurantIdAsync(int restaurantId);
        Task UpdateRestaurantWorkingHoursAsync(int restaurantId, List<UpdateWorkingHoursDto> workingHours);
    }
}