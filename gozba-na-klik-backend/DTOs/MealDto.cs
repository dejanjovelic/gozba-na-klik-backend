using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs
{
    public class MealDto
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? MealImageUrl { get; set; }
        public int RestaurantId { get; set; }
        public List<Allergen>? Allergens { get; set; } = new List<Allergen>();
        public List<Extras>? Extras { get; set; } = new List<Extras>();
    }
}
