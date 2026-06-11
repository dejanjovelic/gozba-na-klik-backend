using gozba_na_klik_backend.Services.DTOs.NonWorkingDateDtos;
using gozba_na_klik_backend.Services.DTOs.WorkingHoursDtos;
using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Services.DTOs.RestaurantDtos
{
    public class RestaurantWithWorkingHoursAndNonWokingDaysDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double AverageRating { get; set; }
        public string? RestaurantImageUrl { get; set; }
        public bool IsCreated { get; set; }
        public string RestaurantOwnerId { get; set; }
        public List<WorkingHoursDto>? WorkingHours { get; set; } = new List<WorkingHoursDto>();
        public List<NonWorkingDateResponseDto>? NonWorkingDates { get; set; } = new List<NonWorkingDateResponseDto>();
    }
}
