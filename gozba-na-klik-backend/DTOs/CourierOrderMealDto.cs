using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs
{
    public class CourierOrderMealDto
    {
        public int OrderId { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }
        public int Quantity { get; set; }
    }
}
