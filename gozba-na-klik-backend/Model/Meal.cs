namespace gozba_na_klik_backend.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? MealImageUrl { get; set; }
        public List<Allergens>? Allergens { get; set; } = new List<Allergens>();
        public List<Extras>? Extras { get; set; } = new List<Extras>();

    }
}
