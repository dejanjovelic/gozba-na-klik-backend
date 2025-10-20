namespace gozba_na_klik_backend.DTOs
{
    public class RestaurantFilterDto
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public int? CapacityFrom { get; set; }
        public int? CapacityTo { get; set; }
        public double? AverageRatingform { get; set; }
        public double? AverageRatingTo { get; set; }
    }
}
