using AutoMapper;
using gozba_na_klik_backend.Controllers;
using gozba_na_klik_backend.Infrastructure;
using gozba_na_klik_backend.Infrastructure.Repository;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.NonWorkingDateDtos;
using gozba_na_klik_backend.Services.DTOs.RestaurantDtos;
using gozba_na_klik_backend.Services.DTOs.WorkingHoursDtos;
using gozba_na_klik_backend.Services.Exceptions;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Linq;
using System.Security.Claims;
using ZstdSharp;
using ZstdSharp.Unsafe;

namespace gozba_na_klik_backend.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantOwnerRepository _restaurantOwnerRepository;
        private readonly IWorkingHoursService _workingHoursService;
        private readonly INonWorkingDateService _nonWorkingDateService;
        private readonly ILogger<RestaurantService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantService(
            IRestaurantRepository restaurantRepository,
            IRestaurantOwnerRepository restaurantOwnerRepository,
            IWorkingHoursService workingHoursService,
            INonWorkingDateService nonWorkingDateService,
            ILogger<RestaurantService> logger,
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _restaurantRepository = restaurantRepository;
            _restaurantOwnerRepository = restaurantOwnerRepository;
            _workingHoursService = workingHoursService;
            _nonWorkingDateService = nonWorkingDateService;
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RestaurantDto>> GetTopRatedRestaurantsAsync()
        {
            _logger.LogInformation("Getting 10 top rated restaurants");
            List<Restaurant> restaurants = await _restaurantRepository.GetTopRatedRestaurantsAsync();
            return restaurants.Select(_mapper.Map<RestaurantDto>).ToList();
        }

        public async Task<PaginatedListDto<Restaurant>> GetAllFilteredAndSortedAndPagedAsync(RestaurantFilterDto restaurantFilter, int sortType, int page, int pageSize)
        {
            ValidatePageData(page, pageSize);
            return await _restaurantRepository.GetAllFilteredAndSortedAndPagedAsync(restaurantFilter, sortType, page, pageSize);
        }

        public async Task<PaginatedListDto<Restaurant>> GetAllRestaurantsPaginatedAsync(int page, int pageSize)
        {
            ValidatePageData(page, pageSize);
            return await _restaurantRepository.GetAllRestaurantsPaginatedAsync(page, pageSize);
        }

        public async Task<List<RestaurantBasicDataDto>> GetAllRestaurantsAsync()
        {
            _logger.LogInformation("fetching all resturants from database.");
            List<Restaurant> restaurantsFromDb = await _restaurantRepository.GetAllRestaurantsAsync();
            return restaurantsFromDb.Select(_mapper.Map<RestaurantBasicDataDto>).ToList();
        }

        public async Task<List<RestaurantBasicDataDto>> GetAllRestaurantsByOwnerIdAsync(string userId, string ownerId)
        {
            ValidateRestaurantOwnership(userId, ownerId);

            _logger.LogInformation($"fetching all owners (owner Id: {ownerId}) resturants from database.");
            List<Restaurant> restaurantsFromDb = await _restaurantRepository.GetAllRestaurantsByOwnerIdAsync(ownerId);
            return restaurantsFromDb.Select(_mapper.Map<RestaurantBasicDataDto>).ToList();
        }

        public async Task<RestaurantWithMealsDto> GetRestaurantWithMealsAsync(int restaurantId)
        {
            Restaurant restaurant = await GetRestaurantOrThrowAsync(restaurantId);

            return _mapper.Map<RestaurantWithMealsDto>(restaurant);
        }

        public async Task<RestaurantWithWorkingHoursAndNonWokingDaysDto> GetRestaurantWithWorkingDaysAndNonWorkingDaysAsync(string userId, int restaurantId)
        {
            Restaurant restaurant = await GetRestaurantOrThrowAsync(restaurantId);
            ValidateRestaurantOwnership(userId, restaurant.RestaurantOwnerId);
            return _mapper.Map<RestaurantWithWorkingHoursAndNonWokingDaysDto>(restaurant);
        }

        public async Task<RestaurantBasicDataDto> GetRestaurantBasicDataByIdAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetRestaurantByIdAsync(id);
            return _mapper.Map<RestaurantBasicDataDto>(restaurant);
        }

        public List<RestaurantSortTypeOptionDto> GetAllSortTypes()
        {
            List<RestaurantSortTypeOptionDto> restaurantSortTypeOptions = new List<RestaurantSortTypeOptionDto>();
            var enumValues = Enum.GetValues(typeof(RestaurantSortType));
            foreach (RestaurantSortType sortType in enumValues)
            {
                restaurantSortTypeOptions.Add(new RestaurantSortTypeOptionDto(sortType));
            }
            return restaurantSortTypeOptions;
        }

        public async Task<RestaurantBasicDataDto> CreateRestaurantAsync(CreateRestaurantDto restaurantDto)
        {
            await ValidateRestaurantOwnerExistenceAsync(restaurantDto.RestaurantOwnerId);

            Restaurant newRestaurant = _mapper.Map<Restaurant>(restaurantDto);
            newRestaurant.IsCreated = false;
            Restaurant createdRestaurant = await _restaurantRepository.CreateRestaurantAsync(newRestaurant);
            List<UpdateWorkingHoursDto> workingHours = new List<UpdateWorkingHoursDto>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                workingHours.Add(new UpdateWorkingHoursDto
                {
                    DayOfTheWeek = day,
                    EndingTime = null,
                    StartingTime = null,
                    RestaurantId = createdRestaurant.Id
                });
            }
            await _workingHoursService.UpdateRestaurantWorkingHoursAsync(createdRestaurant, workingHours);
            return _mapper.Map<RestaurantBasicDataDto>(createdRestaurant);
        }

        public async Task<RestaurantWithWorkingHoursAndNonWokingDaysDto> UpdateRestaurantAsync(string userId, int resturantId, UpdateRestaurantDto updateRestaurantDto)
        {
            _logger.LogInformation("Starting update for restaurant with Id: {RestaurantId}", resturantId);
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                ValidateMatchingIds(resturantId, updateRestaurantDto.Id);

                Restaurant restaurant = await GetRestaurantOrThrowAsync(resturantId);
                _logger.LogInformation("Updating restaurant with Id: {RestaurantId} using DTO: {@UpdateDto}", restaurant.Id, updateRestaurantDto);

                ValidateRestaurantOwnership(userId, restaurant.RestaurantOwnerId);

                _mapper.Map(updateRestaurantDto, restaurant);

                _logger.LogInformation("Validating restaurant data completeness before publishing. RestaurantId={RestaurantId}", restaurant.Id);
                restaurant.IsCreated = IsRestaurantDataComplete(restaurant);

                _logger.LogInformation("Recalculating average rating for restaurant {RestaurantId}", restaurant.Id);
                await UpdateRestaurantAverageRatingAsync(restaurant.Id);

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Committing transaction for restaurant update {RestaurantId}", restaurant.Id);
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Restaurant {RestaurantId} successfully updated.", restaurant.Id);
                return _mapper.Map<RestaurantWithWorkingHoursAndNonWokingDaysDto>(restaurant);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        private static bool IsRestaurantDataComplete(Restaurant restaurant)
        {
            return !string.IsNullOrWhiteSpace(restaurant.Name) &&
                                !string.IsNullOrWhiteSpace(restaurant.Address) &&
                                !string.IsNullOrWhiteSpace(restaurant.City) &&
                                restaurant.Capacity != null &&
                                !string.IsNullOrWhiteSpace(restaurant.Description) &&
                                restaurant.Id > 0 &&
                                restaurant.WorkingHours.Any(wh => wh.StartingTime != new TimeSpan(00, 00, 00)) &&
                                restaurant.WorkingHours.Any(wh => wh.EndingTime != new TimeSpan(00,00,00));
        }

        public async Task<RestaurantBasicDataDto> UpdateRestaurantBasicDataAsync(ClaimsPrincipal claimsPrincipal, int resturantId, UpdateRestaurantBasicDataDto updateRestaurantBasicDataDto)
        {
            ApplicationUser user = await _userManager.GetUserAsync(claimsPrincipal);
            Restaurant restaurant = await GetRestaurantOrThrowAsync(resturantId);

            if (await _userManager.IsInRoleAsync(user, "RestaurantOwner"))
            {
                ValidateRestaurantOwnership(user.Id, restaurant.RestaurantOwnerId);
            }

            _mapper.Map(updateRestaurantBasicDataDto, restaurant);
            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
            return _mapper.Map<RestaurantBasicDataDto>(restaurant);
        }

        public async Task<RestaurantWithWorkingHoursAndNonWokingDaysDto> UpdateRestaurantImageAsync(string userId, int restaurantId, string restaurantImageUrl)
        {
            Restaurant restaurant = await GetRestaurantOrThrowAsync(restaurantId);
            ValidateRestaurantOwnership(userId, restaurant.RestaurantOwnerId);
            restaurant.RestaurantImageUrl = restaurantImageUrl;
            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
            return _mapper.Map<RestaurantWithWorkingHoursAndNonWokingDaysDto>(restaurant);
        }

        public async Task<RestaurantWithWorkingHoursAndNonWokingDaysDto> UpdateRestaurantWorkingHoursAsync(string userId, int restaurantId, List<UpdateWorkingHoursDto> newWorkingHours)
        {
            Restaurant restaurant = await GetRestaurantOrThrowAsync(restaurantId);
            ValidateRestaurantOwnership(userId, restaurant.RestaurantOwnerId);
            await _workingHoursService.UpdateRestaurantWorkingHoursAsync(restaurant, newWorkingHours);
            return _mapper.Map<RestaurantWithWorkingHoursAndNonWokingDaysDto>(restaurant);
        }

        public async Task<RestaurantWithWorkingHoursAndNonWokingDaysDto> UpdateRestaurantNonWorkingDatesAsync(string userId, int restaurantId, List<CreateNonWorkingDateDto> nonWorkingDatesDtos)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                Restaurant restaurant = await GetRestaurantOrThrowAsync(restaurantId);
                ValidateRestaurantOwnership(userId, restaurant.RestaurantOwnerId);

                await _nonWorkingDateService.DeleteRestaurantNonWorkingDatesAsync(restaurant, nonWorkingDatesDtos);
                await _nonWorkingDateService.CreateRestaurantNonWorkingDatesAsync(restaurant, nonWorkingDatesDtos);

                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();

                return _mapper.Map<RestaurantWithWorkingHoursAndNonWokingDaysDto>(restaurant);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateRestaurantImageUrlAsync(string userId, int restaurantId, UpdateRestaurantImageUrlDto updateRestaurantImageUrlDto)
        {
            Restaurant restaurant = await GetRestaurantOrThrowAsync(restaurantId);
            ValidateRestaurantOwnership(userId, restaurant.RestaurantOwnerId);
            if (string.IsNullOrWhiteSpace(updateRestaurantImageUrlDto.RestaurantImageUrl))
            {
                throw new BadRequestException("Invalid restaurant image url data.");
            }

            restaurant.RestaurantImageUrl = updateRestaurantImageUrlDto.RestaurantImageUrl;
            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
        }

        private void ValidateMatchingIds(int routeId, int dtoId)
        {
            if (routeId != dtoId)
            {
                throw new BadRequestException($"Route ID ({routeId}) does not match DTO ID ({dtoId}).");
            }
        }

        public async Task UpdateRestaurantAverageRatingAsync(int restaurantId)
        {
            Restaurant restaurant = await GetRestaurantOrThrowAsync(restaurantId);
            _logger.LogInformation("Fetching restaurant rewievs");

            var reviews = restaurant.Orders
                .Where(o => o.OrderReview != null)
                .Select(o => o.OrderReview!.RestaurantRating)
                .ToList();

            _logger.LogInformation("Calculating restaurant average rating.");
            restaurant.AverageRating = reviews.Count > 0 ? reviews.Average() : 0;

            _logger.LogInformation("Updating restaurant average rating.");
            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            _logger.LogInformation("Attempting to delete restaurant with Id: {RestaurantId}", id);
            Restaurant restaurant = await GetRestaurantOrThrowAsync(id);
            await _restaurantRepository.DeleteRestaurantAsync(restaurant);
            _logger.LogInformation("Restaurant with Id: {RestaurantId} successfully deleted.", id);
        }

        public IEnumerable<string> GetDaysOfTheWeek()
        {
            return DateUtils.GetDaysOfTheWeek();
        }

        public bool IsRestaurantOpen(Restaurant restaurant)
        {
            var now = DateTime.Now.TimeOfDay;
            var today = DateTime.Now.DayOfWeek;

            var todayHours = restaurant.WorkingHours
                .FirstOrDefault(w => w.DayOfTheWeek.ToString() == today.ToString());

            if (todayHours == null)
                return false;

            return now >= todayHours.StartingTime && now <= todayHours.EndingTime;
        }

        private void ValidateRestaurantOwnership(string userId, string restaurantOwnerId, string message = "You do not have permission to perform this action.")
        {
            _logger.LogInformation($"Checking is user with Id:{userId} restaurant owner with Id: {restaurantOwnerId}.");
            if (userId != restaurantOwnerId)
            {
                throw new ForbiddenException(message);
            }
        }

        private void ValidatePageData(int page, int pageSize)
        {
            _logger.LogInformation("Checking paginated page data. Page: {PageNumber}, Size: {PageSize}", page, pageSize);
            if (page < 1)
            {
                throw new BadRequestException("Invalid pagination parameter: 'page' must be a positive integer.");
            }
            if (pageSize < 1)
            {
                throw new BadRequestException("Invalid pagination parameter: 'pageSize' must be a positive integer.");
            }
        }

        private async Task ValidateRestaurantOwnerExistenceAsync(string restaurantOwnerId)
        {
            _logger.LogInformation($"Checking if restaurant owner exists with Id: {restaurantOwnerId}");
            bool restaurantOwnerExist = await _restaurantOwnerRepository.RestaurantOwnerExistsByIdAsync(restaurantOwnerId);
            if (!restaurantOwnerExist)
            {
                throw new NotFoundException($"The restaurant owner with Id: {restaurantOwnerId} not found.");
            }
            _logger.LogInformation($"Restaurant owner with Id: {restaurantOwnerId} exists.");
        }

        private async Task<Restaurant> GetRestaurantOrThrowAsync(int id)
        {
            _logger.LogInformation($"Fetching restaurant with Id:{id} from db.");
            Restaurant restaurant = await _restaurantRepository.GetRestaurantByIdAsync(id);

            if (restaurant == null)
            {
                throw new NotFoundException($"Restaurant with ID {id} not found.");
            }
            _logger.LogInformation($"Restaurant found.");
            return restaurant;
        }
    }
}
