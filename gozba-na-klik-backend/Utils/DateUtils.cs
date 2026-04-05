namespace gozba_na_klik_backend.Utils
{
    public static class DateUtils
    {
        public static IEnumerable<string> GetDaysOfTheWeek() 
        {
            return Enum.GetNames(typeof(DayOfWeek));
        }
    }
}
