using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Domain.IRepositories
{
    public interface INonWorkingDateRepository
    {
        Task CreateRestaurantNonWorkingDatesAsync(List<NonWorkingDate> nonWorkingDates);
        Task DeleteRestaurantNonWorkingDatesAsync(List<NonWorkingDate> nonWorkingDates);
        Task<List<NonWorkingDate>> GetAllByRestaurantIdAsync(int id);
    }
}