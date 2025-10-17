using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface ICourierService
    {
        Task<Courier> CreateAsync(Courier courier);
        Task<Courier?> GetByIdAsync(int courierId);
        Task UpdateWorkingHoursAsync(Courier courier, List<WorkingHours> workingHours);
    }
}