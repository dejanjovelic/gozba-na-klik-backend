using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security;

namespace gozba_na_klik_backend.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;
        private readonly IAuthService _authService;

        public CourierService(ICourierRepository courierRepository, IAuthService authService)
        {
            _courierRepository = courierRepository;
            _authService = authService;
        }

        public async Task<string> CreateAsync(RegistrationDto registrationDto)
        {
            AuthResponseDto authResponseDto = await _authService.RegisterUserAsync(registrationDto, "Courier");
            Courier courier = new Courier
            {
                Id = authResponseDto.AplicationUserId
            };

            await _courierRepository.CreateAsync(courier);

            return authResponseDto.Token;
        }

        public async Task<CourierDto> GetByIdAsync(string courierId, string? ownerId)
        {
            ValidateInputData(courierId, ownerId);

            var courier = await _courierRepository.GetByIdAsync(courierId);

            if (courier == null)
            {
                throw new NotFoundException("Courier not found.");
            }
            return new CourierDto
            {
                Id = courier.ApplicationUser.Id,
                Username = courier.ApplicationUser.UserName,
                Name = courier.ApplicationUser.Name,
                Surname = courier.ApplicationUser.Surname,
                WorkingHours = courier.WorkingHours.Select(wh => new WorkingHoursDto
                {
                    DayOfTheWeek = wh.DayOfTheWeek.ToString(),
                    StartingTime = wh.StartingTime.ToString(@"hh\:mm\:ss"),
                    EndingTime = wh.EndingTime.ToString(@"hh\:mm\:ss")
                }).ToList()
            };
        }

        public async Task UpdateWorkingHoursAsync(string courierId, List<WorkingHours> workingHours, string? ownerId)
        {
            ValidateInputData(courierId, ownerId);

            var courier = await _courierRepository.GetByIdAsync(courierId);

            if (courier == null)
            {
                throw new NotFoundException("Courier not found.");
            }
            await _courierRepository.UpdateWorkingHoursAsync(courier, workingHours);
        }

        private static void ValidateInputData(string courierId, string? ownerId)
        {
            if (ownerId != courierId)
            {
                throw new ForbiddenException($"Courier with Id: {courierId} do not have permission to perform this action.");
            }

            if (string.IsNullOrWhiteSpace(courierId))
            {
                throw new BadRequestException("Invalid courier ID.");
            }
        }

        public async Task UpdateCourierStatusAsync()
        {
            await _courierRepository.UpdateCourierStatusAsync();
        }
        public async Task<List<Courier>> GetAllAsync()
        {
            return await _courierRepository.GetAllAsync();
        }
    }
}
