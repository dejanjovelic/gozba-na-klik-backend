using gozba_na_klik_backend.Services.DTOs;

namespace gozba_na_klik_backend.Services.DTOs.CourierDtos
{
    public class CourierShortDto
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public List<WorkingHoursDto> WorkingHours { get; set; } = new();
    }
}
