using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Services.DTOs.NonWorkingDateDtos
{
    public class CreateNonWorkingDateDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int RestaurantId { get; set; }
    }
}
