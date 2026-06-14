namespace gozba_na_klik_backend.Services.DTOs.WorkingHoursDtos
{
    public class WorkingHoursDto
    {
        public string DayOfTheWeek { get; set; } = string.Empty;
        public string StartingTime { get; set; } = string.Empty;
        public string EndingTime { get; set; } = string.Empty;
        public bool? IsRestaurantOpen { get; set; }
        public int? RestaurantId { get; set; }
        public string? CourierId { get; set; }
    }
}
