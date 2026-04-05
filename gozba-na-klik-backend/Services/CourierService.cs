using AutoMapper;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;
using gozba_na_klik_backend.Services.DTOs.CourierDtos;

namespace gozba_na_klik_backend.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public CourierService(
            ICourierRepository courierRepository,
            IAuthService authService, IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IUnitOfWork unitOfWork
            )
        {
            _courierRepository = courierRepository;
            _authService = authService;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCourierDto> CreateAsync(RegistrationDto registrationDto)
        {
            AuthResponseDto authResponseDto = await _authService.RegisterUserAsync(registrationDto, "Courier");
            Courier courier = new Courier
            {
                Id = authResponseDto.AplicationUserId
            };

            await _courierRepository.CreateAsync(courier);
            courier = await _courierRepository.GetByIdAsync(authResponseDto.AplicationUserId);
            var roles = await _userManager.GetRolesAsync(courier.ApplicationUser);
            var result = _mapper.Map<CreateCourierDto>(courier);
            result.Role = roles.FirstOrDefault();

            return result;
        }

        public async Task<CourierDto> GetByIdAsync(string courierId, string? ownerId)
        {
            ValidateInputData(courierId, ownerId);
            Courier courier = await GetCourierOrThrow(courierId);

            return _mapper.Map<CourierDto>(courier);
        }

        public async Task UpdateWorkingHoursAsync(string courierId, List<WorkingHours> workingHours, string? ownerId)
        {
            ValidateInputData(courierId, ownerId);
            Courier courier = await GetCourierOrThrow(courierId);

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _courierRepository.DeleteWorkingHoursAsync(courier.WorkingHours);

                workingHours.ForEach(wh => wh.CourierId = courierId);

                await _courierRepository.UpdateWorkingHoursAsync(workingHours);

                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateCourierStatusAsync()
        {
            var now = DateTime.Now;
            var currentDay = now.DayOfWeek;
            var currentTime = now.TimeOfDay;
            List<Courier> couriers = await _courierRepository.GetAllAsync();
            foreach (var courier in couriers)
            {
                // Check if any of today's working hours include the current time
                bool isWorkingNow = courier.WorkingHours?
                    .Any(wh => wh.DayOfTheWeek == currentDay &&
                               currentTime >= wh.StartingTime &&
                               currentTime <= wh.EndingTime)
                    ?? false;

                courier.Active = isWorkingNow;
            }
            await _courierRepository.UpdateCourierStatusAsync(couriers);
        }

        public async Task<List<Courier>> GetAllAsync()
        {
            return await _courierRepository.GetAllAsync();
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

        private async Task<Courier> GetCourierOrThrow(string id)
        {
            var courier = await _courierRepository.GetByIdAsync(id);

            if (courier == null)
            {
                throw new NotFoundException($"Courier with Id: {id} not found.");
            }

            return courier;
        }
    }
}
