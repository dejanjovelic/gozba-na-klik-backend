using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Domain.IRepositories
{
    public interface INonWorkingDateRepository
    {
        Task<List<NonWorkingDate>> CreateRestaurantNonWorkingDatesAsync(List<NonWorkingDate> nonWorkingDates);
        Task<List<NonWorkingDate>> GetAllByRestaurantIdAsync(int id);
    }
}