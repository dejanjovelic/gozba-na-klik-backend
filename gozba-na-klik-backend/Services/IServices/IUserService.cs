using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByUsernameAsync(string username);
    }
}