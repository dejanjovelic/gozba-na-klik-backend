using AutoMapper;
using gozba_na_klik_backend.Domain.IRepositories;
using gozba_na_klik_backend.Infrastructure.Repository;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.DTOs.WorkingHoursDtos;
using gozba_na_klik_backend.Services.Exceptions;
using gozba_na_klik_backend.Services.IServices;

namespace gozba_na_klik_backend.Services
{
    public class WorkingHoursService : IWorkingHoursService
    {
        private readonly IWorkingHoursRepository _workingHoursRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkingHoursRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public WorkingHoursService(
            IWorkingHoursRepository workingHoursRepository,
            IRestaurantRepository restaurantRepository,
            IMapper mapper,
            ILogger<WorkingHoursRepository> logger,
            IUnitOfWork unitOfWork
            )
        {
            _workingHoursRepository = workingHoursRepository;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<WorkingHoursDto>> GetAllByRestaurantIdAsync(int restaurantId)
        {
            if (!await _restaurantRepository.RestaurantExistsAsync(restaurantId))
            {
                throw new NotFoundException($"The Restaurant with Id: {restaurantId} not found.");
            }

            return (await _workingHoursRepository.GetAllByRestaurantIdAsync(restaurantId)).Select(_mapper.Map<WorkingHoursDto>).ToList();

        }

        public async Task UpdateRestaurantWorkingHoursAsync(int restaurantId, List<UpdateWorkingHoursDto> workingHoursDtos)
        {
            Restaurant restaurant = await GetRestaurantOrThrowAsync(restaurantId);
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _workingHoursRepository.DeleteAsync(restaurant.WorkingHours);

                List<WorkingHours> workingHours = _mapper.Map<List<WorkingHours>>(workingHoursDtos);

                workingHours.ForEach(wh => wh.RestaurantId = restaurantId);

                await _workingHoursRepository.UpdateRestaurantWorkingHoursAsync(workingHours);

                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();

            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        private async Task<Restaurant> GetRestaurantOrThrowAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                throw new NotFoundException($"The restaurant wit Id: {id} not found.");
            }
            return restaurant;
        }


    }
}
