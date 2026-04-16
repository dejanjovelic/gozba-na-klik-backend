namespace gozba_na_klik_backend.Services.DTOs.RestaurantDtos
{
    public class RestaurantBasicDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public int? Capacity { get; set; }
        public string? RestaurantImageUrl { get; set; }
        public string RestaurantOwnerId { get; set; }
        public bool IsCreated { get; set; }
    }
}
