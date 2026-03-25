namespace gozba_na_klik_backend.Model
{
    public class OrderMeal
    {
        public int OrderId { get; set; }
        public int MealId { get; set; }
        public Meal? Meal { get; set; }
        public int Quantity { get; set; }

    }
}
