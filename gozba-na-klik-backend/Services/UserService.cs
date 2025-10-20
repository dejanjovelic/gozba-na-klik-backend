using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.EntityFrameworkCore;
using gozba_na_klik_backend.DTOs;

namespace gozba_na_klik_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }
        public async Task<UserDto> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new BadRequestException("Username and password are required.");
            }

            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || user.Password != password)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                ProfileImageUrl = user.ProfileImageUrl,
                Role = user.Role.ToString()
            };
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
         
        }
    }
}
