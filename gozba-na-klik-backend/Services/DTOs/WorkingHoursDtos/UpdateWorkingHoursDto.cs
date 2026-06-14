namespace gozba_na_klik_backend.Services.DTOs.WorkingHoursDtos
{
    public class UpdateWorkingHoursDto
    {
        public DayOfWeek DayOfTheWeek { get; set; }
        public TimeSpan? StartingTime { get; set; }
        public TimeSpan? EndingTime { get; set; }
        public bool? IsRestaurantOpen { get; set; }
        public int? RestaurantId { get; set; }
        public string? CourierId { get; set; }
    }
}
