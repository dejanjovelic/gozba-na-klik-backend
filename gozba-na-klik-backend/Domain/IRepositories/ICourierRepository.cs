using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface ICourierRepository
    {
        Task<Courier> CreateAsync(Courier courier);
        Task<Courier?> GetByIdAsync(string courierId);
        Task UpdateWorkingHoursAsync(List<WorkingHours> workingHours);
        Task<List<Courier>> GetAllAsync();
        Task UpdateCourierStatusAsync(List<Courier> couriers);
        Task DeleteWorkingHoursAsync(List<WorkingHours> workingHours);
    }
}
