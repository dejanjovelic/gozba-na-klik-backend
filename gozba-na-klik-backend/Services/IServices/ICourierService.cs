using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface ICourierService
    {
        Task<NewCourierDto> CreateAsync(RegistrationDto registrationDto);
        Task<CourierDto> GetByIdAsync(string courierId, string? ownerId);
        Task UpdateWorkingHoursAsync(string courierId, List<WorkingHours> workingHours, string? ownerId);
        Task<List<Courier>> GetAllAsync();
        Task UpdateCourierStatusAsync();
    }
}