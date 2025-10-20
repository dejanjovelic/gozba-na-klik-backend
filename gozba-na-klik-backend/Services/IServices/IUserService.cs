using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IUserService
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<UserDto> LoginAsync(string username, string password);
        Task<List<User>> GetAllAsync();
    }
}