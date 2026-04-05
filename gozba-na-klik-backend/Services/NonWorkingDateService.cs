using AutoMapper;
using gozba_na_klik_backend.Domain.IRepositories;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.DTOs.NonWorkingDateDtos;
using gozba_na_klik_backend.Services.Exceptions;
using gozba_na_klik_backend.Services.IServices;

namespace gozba_na_klik_backend.Services
{
    public class NonWorkingDateService : INonWorkingDateService
    {
        private readonly INonWorkingDateRepository _nonWorkingDateRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public NonWorkingDateService(INonWorkingDateRepository nonWorkingDateRepository, IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _nonWorkingDateRepository = nonWorkingDateRepository;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<List<NonWorkingDateResponseDto>> GetAllByRestaurantIdAsync(int RestaurantId)
        {
            List<NonWorkingDate> nonWorkingDates = await _nonWorkingDateRepository.GetAllByRestaurantIdAsync(RestaurantId);
            return nonWorkingDates.Select(_mapper.Map<NonWorkingDateResponseDto>).ToList();
        }

        public async Task<List<NonWorkingDateResponseDto>> CreateRestaurantNonWorkingDatesAsync(int restaurantId, List<CreateNonWorkingDateDto> createNonWorkingDatesDtos)
        {
            bool restaurantExist = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
            if (!restaurantExist)
            {
                throw new NotFoundException($"The Restaurant with Id: {restaurantId} not found.");
            }

            List<NonWorkingDate> nonWorkingDates = _mapper.Map<List<NonWorkingDate>>(createNonWorkingDatesDtos);

            nonWorkingDates = await _nonWorkingDateRepository.CreateRestaurantNonWorkingDatesAsync(nonWorkingDates);
            return _mapper.Map<List<NonWorkingDateResponseDto>>(nonWorkingDates);
        }
    }
}
