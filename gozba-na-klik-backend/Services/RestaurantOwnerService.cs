using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
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

        public RestaurantOwnerService(IRestaurantOwnerRepository restaurantOwnerRepository, IAuthService authService)
        {
            _restaurantOwnerRepository = restaurantOwnerRepository;
            _authService = authService;
        }

        [Authorize(Policy = "CreateUserByAdmin")]
        public async Task<string> CreateAsync(RegistrationDto registrationDto)
        {
            AuthResponseDto authResponseDto = await _authService.RegisterUserAsync(registrationDto, "RestaurantOwner");

            RestaurantOwner restaurantOwner = new RestaurantOwner
            {
                Id = authResponseDto.AplicationUserId
            };

            await _restaurantOwnerRepository.CreateAsync(restaurantOwner);

            return authResponseDto.Token;
        }
    }
}
