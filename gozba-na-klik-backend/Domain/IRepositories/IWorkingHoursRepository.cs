using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Domain.IRepositories
{
    public interface IWorkingHoursRepository
    {
        Task DeleteAsync(List<WorkingHours> workingHours);
        Task<List<WorkingHours>> GetAllByRestaurantIdAsync(int restaurantId);
        Task UpdateRestaurantWorkingHoursAsync(List<WorkingHours> workingHours);
    }
}