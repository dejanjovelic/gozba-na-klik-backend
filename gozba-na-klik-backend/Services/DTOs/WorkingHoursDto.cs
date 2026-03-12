namespace gozba_na_klik_backend.Services.DTOs
{
    public class WorkingHoursDto
    {
        public string DayOfTheWeek { get; set; } = string.Empty;
        public string StartingTime { get; set; } = string.Empty;
        public string EndingTime { get; set; } = string.Empty;
    }
}
