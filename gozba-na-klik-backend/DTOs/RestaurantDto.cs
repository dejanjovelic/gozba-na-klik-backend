namespace gozba_na_klik_backend.DTOs
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double AverageRating { get; set; } = 5;
        public string? RestaurantImageUrl { get; set; }
        public string RestaurantOwnerId { get; set; }

    }
}
