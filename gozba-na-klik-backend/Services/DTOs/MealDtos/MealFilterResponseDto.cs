using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;

namespace gozba_na_klik_backend.Services.DTOs.MealDtos
{
    public class MealFilterResponseDto
    {
        public PaginatedListDto<MealWithAllergensDto> Meals { get; set; } = new PaginatedListDto<MealWithAllergensDto>();
        public List<AllergenWithFlagDto> AllAllergens { get; set; } = new List<AllergenWithFlagDto>();
        
    }
}
