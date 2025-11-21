using System.Text.Json.Serialization;

namespace gozba_na_klik_backend.Model
{
    public class Order
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        [JsonIgnore]
        public Courier Courier { get; set; }
        public int? CourierId { get; set; }
        public DateTime? OrderTime { get; set; }
        public DateTime? AssignedAt { get; set; }

        public OrderStatus Status { get; set; }
        [JsonIgnore]
        public List<OrderMeal> OrderItems { get; set; } = new List<OrderMeal>();
    }
}
