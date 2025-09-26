namespace gozba_na_klik_backend.Model
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public string DayOfTheWeek { get; set; }
        public TimeSpan StartingTime { get; set; }
        public DateTime EndingTime { get; set; }= DateTime.MinValue;
    }
}
