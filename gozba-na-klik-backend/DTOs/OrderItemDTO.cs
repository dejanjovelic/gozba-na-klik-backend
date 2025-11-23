namespace gozba_na_klik_backend.DTOs
{
    public class OrderItemDTO
    {
        public string MealName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total => Price * Quantity; 
    }
}
