using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
            return await _courierRepository.CreateAsync(courier);
        }
        public async Task<Courier?> GetByIdAsync(int courierId)
        {
            return await _courierRepository.GetByIdAsync(courierId);
        }

        public async Task UpdateWorkingHoursAsync(Courier courier, List<WorkingHours> workingHours)
        {
            if (courier == null)
            {
                throw new BadRequestException("Courier not found");
            }
            await _courierRepository.UpdateWorkingHoursAsync(courier, workingHours);
        }
    }
}
