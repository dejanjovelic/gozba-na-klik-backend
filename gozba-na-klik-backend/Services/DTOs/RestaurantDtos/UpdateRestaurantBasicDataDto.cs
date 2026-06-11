using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Services.DTOs.RestaurantDtos
{
    public class UpdateRestaurantBasicDataDto
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

    }
}


