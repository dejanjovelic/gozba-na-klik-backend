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

        public async Task CreateRestaurantNonWorkingDatesAsync(Restaurant restaurant, List<CreateNonWorkingDateDto> createNonWorkingDatesDtos)
        {
            var existingDates = new HashSet<DateTime>(restaurant.NonWorkingDates.Select(nwd => nwd.Date.Date));

            List<NonWorkingDate> newNonWorkingDates = createNonWorkingDatesDtos
                .Where(cnwd => !existingDates.Contains(cnwd.Date.Date))
                .Select(cnwd => _mapper.Map<NonWorkingDate>(cnwd))
                .ToList();

            await _nonWorkingDateRepository.CreateRestaurantNonWorkingDatesAsync(newNonWorkingDates);
        }

        public async Task DeleteRestaurantNonWorkingDatesAsync(Restaurant restaurant, List<CreateNonWorkingDateDto> createNonWorkingDateDtos)
        {
            var newDates = new HashSet<DateTime>(createNonWorkingDateDtos.Select(nwd => nwd.Date.Date));

            List<NonWorkingDate> existingNonWorkingDates = restaurant.NonWorkingDates
                .Where(nwd => !newDates.Contains(nwd.Date.Date))
                .ToList();

            await _nonWorkingDateRepository.DeleteRestaurantNonWorkingDatesAsync(existingNonWorkingDates);
        }
    }
}
