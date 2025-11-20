namespace gozba_na_klik_backend.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public Courier Courier { get; set; }
        public int? CourierId { get; set; }
        public TimeSpan? OrderTime { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderMeal> OrderItems { get; set; } = new List<OrderMeal>();
    }
}
