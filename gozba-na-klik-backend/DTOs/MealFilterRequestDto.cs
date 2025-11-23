using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs
{
    public class MealFilterRequestDto
    {
        public string CustomerId { get; set; }
        public bool HideMealsWithAllergens { get; set; } = false;
        public List<int> AdditionalAllergensIds { get; set; } = new List<int>();
        public string? Query { get; set; } = null;

    }
}
