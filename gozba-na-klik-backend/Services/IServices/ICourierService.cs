using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface ICourierService
    {
        Task<Courier> CreateAsync(Courier courier);
        Task<CourierDto> GetByIdAsync(int courierId);
        Task UpdateWorkingHoursAsync(int courierId, List<WorkingHours> workingHours);
    }
}