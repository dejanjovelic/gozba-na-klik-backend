using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IAllergenService _allergenService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public MealService(IMealRepository mealRepository, IAllergenService allergenService, ICustomerService customerService, IMapper mapper)
        {
            this._mealRepository = mealRepository;
            this._allergenService = allergenService;
            this._customerService = customerService;
            this._mapper = mapper;
        }

        public async Task<MealFilterResponseDto> GetFilteredMealsAsync(MealFilterRequestDto mealFilterRequestDto, int page, int pageSize, string? ownerId)
        {
            ValidateRequest(mealFilterRequestDto, page, pageSize, ownerId);

            IQueryable<Meal> meals = _mealRepository.GetAll();

            List<Allergen> allergens = await _allergenService.GetAllAsync();

            List<Allergen> customersAllergens = await _customerService.GetAllCustomerAllergensAsync(mealFilterRequestDto.CustomerId, ownerId);
            IEnumerable<int> combinedAllergensIds = GetCombinedAllergenIds(mealFilterRequestDto, customersAllergens);


            if (!string.IsNullOrWhiteSpace(mealFilterRequestDto.Query))
            {
                meals = FilteredMeals(meals, mealFilterRequestDto.Query);
            }

            List<AllergenWithFlagDto> allAllergensDtos = MapAllergensWithCustomersFlag(allergens, combinedAllergensIds);

            if (mealFilterRequestDto.HideMealsWithAllergens)
            {
                meals = meals.Where(meal => !meal.Allergens.Any(allergen => combinedAllergensIds.Contains(allergen.Id)));
            }

            PaginatedListDto<MealWithAllergensDto> searchedMealsPagePaginated = await PaginateMealsAsync(page, pageSize, meals, combinedAllergensIds);

            return new MealFilterResponseDto
            {
                Meals = searchedMealsPagePaginated,
                AllAllergens = allAllergensDtos
            };
        }

        private async Task<PaginatedListDto<MealWithAllergensDto>> PaginateMealsAsync(int page, int pageSize, IQueryable<Meal> meals, IEnumerable<int> combinedAllergensIds)
        {
            int pageIndex = page - 1;
            int totalRowsCount = await meals.CountAsync();
            List<Meal> selectedMeals = await meals.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            List<MealWithAllergensDto> mealsDto = selectedMeals.Select(_mapper.Map<MealWithAllergensDto>).ToList();
            MarkMealAllergens(combinedAllergensIds, mealsDto);
            PaginatedListDto<MealWithAllergensDto> searchedMealsPagePaginated = new PaginatedListDto<MealWithAllergensDto>(mealsDto, totalRowsCount, pageIndex, pageSize);
            return searchedMealsPagePaginated;
        }

        private static void MarkMealAllergens(IEnumerable<int> combinedAllergensIds, List<MealWithAllergensDto> mealsDto)
        {
            foreach (MealWithAllergensDto meal in mealsDto)
            {
                foreach (AllergenWithFlagDto allergenDto in meal.Allergens)
                {
                    allergenDto.IsCustomerAllergen = combinedAllergensIds.Contains(allergenDto.Id);
                }
            }
            ;
        }

        private List<AllergenWithFlagDto> MapAllergensWithCustomersFlag(List<Allergen> allergens, IEnumerable<int> combinedAllergensIds)
        {
            List<AllergenWithFlagDto> allAllergensDtos = _mapper.Map<List<AllergenWithFlagDto>>(allergens);
            allAllergensDtos.ForEach(allergenDto => allergenDto.IsCustomerAllergen = combinedAllergensIds.Contains(allergenDto.Id));

            return allAllergensDtos;
        }

        private static IEnumerable<int> GetCombinedAllergenIds(MealFilterRequestDto mealFilterRequestDto, List<Allergen> customersAllergens)
        {
            var customerAllergensIds = customersAllergens.Select(allergen => allergen.Id).ToHashSet();
            var combinedAllergensIds = customerAllergensIds.Union(mealFilterRequestDto.AdditionalAllergensIds);
            return combinedAllergensIds;
        }

        private static void ValidateRequest(MealFilterRequestDto mealFilterRequestDto, int page, int pageSize, string? ownerId)
        {
            if (ownerId != mealFilterRequestDto.CustomerId) 
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }

            if (mealFilterRequestDto == null)
            {
                throw new BadRequestException("Request body cannot be null.");
            }

            if (page < 1)
            {
                throw new BadRequestException("Invalid pagination parameter: 'page' must be a positive integer.");
            }
            if (pageSize < 1)
            {
                throw new BadRequestException("Invalid pagination parameter: 'pageSize' must be a positive ineteger.");
            }
        }

        private static IQueryable<Meal> FilteredMeals(IQueryable<Meal> meals, string query)
        {
            string formatedQuery = query.Trim().ToLower();

            meals = meals.Where(meal => meal.MealName.ToLower().Contains(formatedQuery) || meal.Description.ToLower().Contains(formatedQuery));

            return meals;
        }

        public async Task<List<Meal>> GetAllSelectedAsync(List<int> mealsIds)
        {
            List<Meal> meals = await _mealRepository.GetAllSelectedAsync(mealsIds);
            if (meals == null || meals.Count == 0)
            {
                throw new NotFoundException("No meals were found for the provided IDs.");
            }
            if (meals.Count != mealsIds.Count)
            {
                var missingIds = mealsIds.Except(meals.Select(m => m.Id));
                throw new NotFoundException($"Some meals could not be found: {string.Join(", ", missingIds)}.");
            }
            return meals;
        }

    }
}

