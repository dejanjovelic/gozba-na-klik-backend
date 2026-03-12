using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;
using gozba_na_klik_backend.Services.DTOs.CourierDtos;

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