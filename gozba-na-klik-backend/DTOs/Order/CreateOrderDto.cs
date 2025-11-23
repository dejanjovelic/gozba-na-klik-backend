using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs.Order
{
    public class CreateOrderDto
    {
        public string CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int DeliveryAddressId { get; set; }
        public List<OrderMealDto> Items { get; set; } = new();
    }
}
