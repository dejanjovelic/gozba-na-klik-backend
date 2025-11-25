using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.DTOs;

namespace gozba_na_klik_backend.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public string CustomerId { get; set; }
        public Address? DeliveryAddress { get; set; }
        public int DeliveryAddressId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public DateTime? OrderTime { get; set; }
        public DateTime? AssignedAt { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderMeal> OrderItems { get; set; } = new List<OrderMeal>();
        public double TotalPrice { get; set; } = 0;
        public DateTime? DeliveryStartedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public Courier? Courier { get; set; }
        public string? CourierId { get; set; }

    }
}

