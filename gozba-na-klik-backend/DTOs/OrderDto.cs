using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs
{
    public class OrderDto
    {

        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public string CustomerId { get; set; }
        public Address? DeliveryAddress { get; set; }
        public int DeliveryAddressId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public TimeSpan? OrderTime { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderMeal> OrderItems { get; set; } = new List<OrderMeal>();
        public double TotalPrice { get; set; } = 0;
        public TimeSpan? DeliveryStartedAt { get; set; }
        public TimeSpan? DeliveredAt { get; set; }
        public Courier? Courier { get; set; }
        public string CourierId { get; set; }
    }
}
