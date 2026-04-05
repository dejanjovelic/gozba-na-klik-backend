namespace gozba_na_klik_backend.Services.DTOs.RestaurantDtos
{
    public class RestaurantShortenDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? Capacity { get; set; }
        public double? AverageRating { get; set; }
        public string RestaurantOwnerId { get; set; }
        public bool IsCreated { get; set; }
    }
}
