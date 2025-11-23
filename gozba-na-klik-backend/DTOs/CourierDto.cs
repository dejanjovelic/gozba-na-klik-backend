namespace gozba_na_klik_backend.DTOs
{
    public class CourierDto
    {
        public string Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public List<WorkingHoursDto> WorkingHours { get; set; } = new();
    }
}
