namespace gozba_na_klik_backend.Model
{
    public class Order
    {
        public int Id { get; set; }

        public Customer customer { get; set; }
        public string CustomerId { get; set; }

        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }

        public TimeSpan orderTime { get; set; }//kada je porudzbina spremna

        public Meal Meal { get; set; }
        public List<Meal> orderItems { get; set; }
        public OrderStatus Status { get; set; }

    }
}
