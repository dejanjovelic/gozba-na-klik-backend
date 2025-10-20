using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using gozba_na_klik_backend.DTOs;

namespace gozba_na_klik_backend.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;
        public CourierService(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }
        public async Task<Courier> CreateAsync(Courier courier)
        {
            if (courier == null)
            {
                throw new BadRequestException("Invalid courier data.");
            }
            return await _courierRepository.CreateAsync(courier);          
        }

        public async Task<CourierDto> GetByIdAsync(int courierId)
        {
            if (courierId <= 0)
            {
                throw new BadRequestException("Invalid courier ID.");
            }
            var courier = await _courierRepository.GetByIdAsync(courierId);
            if (courier == null)
            {
                throw new NotFoundException("Courier not found.");
            }
            return new CourierDto
            {
                Id = courier.Id,
                Username = courier.Username,
                Name = courier.Name,
                Surname = courier.Surname,
                WorkingHours = courier.WorkingHours.Select(wh => new WorkingHoursDto
                {
                    DayOfTheWeek = wh.DayOfTheWeek.ToString(),
                    StartingTime = wh.StartingTime.ToString(@"hh\:mm\:ss"),
                    EndingTime = wh.EndingTime.ToString(@"hh\:mm\:ss")
                }).ToList()
            };
        }

        public async Task UpdateWorkingHoursAsync(int courierId, List<WorkingHours> workingHours)
        {
            if (courierId <= 0)
            {
                throw new BadRequestException("Invalid courier ID.");
            }
            var courier = await _courierRepository.GetByIdAsync(courierId);
            if (courier == null)
            {
                throw new NotFoundException("Courier not found.");
            }
            await _courierRepository.UpdateWorkingHoursAsync(courier, workingHours);               
        }
    }
}
