using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<ApplicationUserDto>> GetAllAsync()
        {
            List<ApplicationUser> users = await _userManager.Users.ToListAsync();
            var result = new List<ApplicationUserDto>();

            foreach (var user in users) 
            {
                var roles = await _userManager.GetRolesAsync(user);
                var dto = _mapper.Map<ApplicationUserDto>(user);
                dto.Role = roles.FirstOrDefault();
                result.Add(dto);
            }
            
            return result;

        } 
    }
}
