using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs.Order
{
    public class CustomerOrderResponseDto
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantImageUrl { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? EstimatedDeliveryTime { get; set; }
        public DateOnly? OrderDate { get; set; }
        public double TotalPrice { get; set; }
    }
}
