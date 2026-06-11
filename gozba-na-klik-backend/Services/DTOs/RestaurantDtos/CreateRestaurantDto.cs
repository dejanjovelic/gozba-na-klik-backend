using gozba_na_klik_backend.Model;
using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Services.DTOs.RestaurantDtos
{
    public class CreateRestaurantDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public string RestaurantOwnerId { get; set; }

        public bool IsCreated { get; set; }
    }
}
