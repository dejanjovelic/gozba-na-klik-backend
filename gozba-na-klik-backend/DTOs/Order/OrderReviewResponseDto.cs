using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs.Order
{
    public class OrderReviewResponseDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Range(1, 10)]
        public int RestaurantRating { get; set; }
        public string? RestaurantComment { get; set; }
        public string? RestaurantReviewImage { get; set; }
        public DateTime PostedAt { get; set; }

    }
}
