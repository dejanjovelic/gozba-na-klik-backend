namespace gozba_na_klik_backend.Model
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }
        public TimeSpan StartingTime { get; set; }
        public TimeSpan EndingTime { get; set; }
    }
}
