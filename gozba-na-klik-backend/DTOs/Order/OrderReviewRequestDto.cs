using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs.Order
{
    public class OrderReviewRequestDto
    {
        [Required]
        public int RestaurantId { get; set; }

        [Range(1, int.MaxValue)]
        public int Page {  get; set; }
    }
}
