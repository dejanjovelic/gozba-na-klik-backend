using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs
{
    public class MealFilterResponseDto
    {
        public PaginatedListDto<MealWithAllergensDto> Meals { get; set; } = new PaginatedListDto<MealWithAllergensDto>();
        public List<AllergenWithFlagDto> AllAllergens { get; set; } = new List<AllergenWithFlagDto>();
        
    }
}
