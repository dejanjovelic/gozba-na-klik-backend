using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;
using gozba_na_klik_backend.Services.DTOs.RestaurantOwnerDtos;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Services
{
    public class RestaurantOwnerService : IRestaurantOwnerService
    {
        private readonly IRestaurantOwnerRepository _restaurantOwnerRepository;
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public RestaurantOwnerService(IRestaurantOwnerRepository restaurantOwnerRepository, IAuthService authService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _restaurantOwnerRepository = restaurantOwnerRepository;
            _authService = authService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateRestaurantOwnerDto> CreateAsync(RegistrationDto registrationDto)
        {
            AuthResponseDto authResponseDto = await _authService.RegisterUserAsync(registrationDto, "RestaurantOwner");

            RestaurantOwner restaurantOwner = new RestaurantOwner
            {
                Id = authResponseDto.AplicationUserId
            };

            await _restaurantOwnerRepository.CreateAsync(restaurantOwner);
            restaurantOwner = await _restaurantOwnerRepository.GetByIdAsync(authResponseDto.AplicationUserId);
            var roles = await _userManager.GetRolesAsync(restaurantOwner.ApplicationUser);
            var result = _mapper.Map<CreateRestaurantOwnerDto>(restaurantOwner);
            result.Role = roles.FirstOrDefault();

            return result;
        }

        public async Task<List<RestaurantOwnerShortResponseDto>> GetAllAsync() 
        {
            List<RestaurantOwner> restaurantOwners = await _restaurantOwnerRepository.GetAllAsync();

            return _mapper.Map<List<RestaurantOwnerShortResponseDto>>(restaurantOwners);
        }
    }
}
