using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface ICourierRepository
    {
        Task<Courier> CreateAsync(Courier courier);
        Task<Courier?> GetByIdAsync(int courierId);
        Task UpdateWorkingHoursAsync(Courier courier, List<WorkingHours> workingHours);
       
    }
}
