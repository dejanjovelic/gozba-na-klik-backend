using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.NonWorkingDateDtos;
using gozba_na_klik_backend.Services.DTOs.WorkingHoursDtos;
using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Services.DTOs.RestaurantDtos
{
    public class UpdateRestaurantDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Capacity { get; set; }

        public double? AverageRating { get; set; }
        public string? RestaurantImageUrl { get; set; }
        public bool IsCreated { get; set; }

        [Required]
        public string RestaurantOwnerId { get; set; }

        public List<UpdateWorkingHoursDto>? WorkingHours { get; set; } = new List<UpdateWorkingHoursDto>();
        public List<CreateNonWorkingDateDto>? NonWorkingDates { get; set; } = new List<CreateNonWorkingDateDto>();

    }
}
