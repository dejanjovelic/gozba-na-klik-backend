namespace gozba_na_klik_backend.Services.DTOs.Order
{
    public class OrderItemDTO
    {
        public string MealName { get; set; }
        public double MealPrice { get; set; }
        public int Quantity { get; set; }
        public double Total => MealPrice * Quantity; 
    }
}
