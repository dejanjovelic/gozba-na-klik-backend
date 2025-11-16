namespace gozba_na_klik_backend.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public Address? DeliveryAddress { get; set; }
        public int DeliveryAddressId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public TimeSpan? OrderTime { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderMeal> OrderItems { get; set; } = new List<OrderMeal>();
        public double TotalPrice { get; set; } = 0;
    }
}
