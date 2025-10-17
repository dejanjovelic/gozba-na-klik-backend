using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<List<User>> GetAllAsync();
        
    }
}
