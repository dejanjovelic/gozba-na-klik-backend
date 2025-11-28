namespace gozba_na_klik_backend.DTOs
{
    public class OrderItemDTO
    {
        public string MealName { get; set; }
        public double MealPrice { get; set; }
        public int Quantity { get; set; }
        public double Total => MealPrice * Quantity; 
    }
}
