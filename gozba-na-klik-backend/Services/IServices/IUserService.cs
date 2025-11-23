using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.DTOs;
namespace gozba_na_klik_backend.Services.IServices
{
    public interface IUserService
    {
        Task<List<ApplicationUserDto>> GetAllAsync();
    }
}