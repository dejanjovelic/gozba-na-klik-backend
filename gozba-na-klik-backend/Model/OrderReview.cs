using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Model
{
    public class OrderReview
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        [Range(1, 10)]
        public int RestaurantRating { get; set; }
        public string? RestaurantComment { get; set; }
        public string? RestaurantReviewImage { get; set; }
        [Range(1, 10)]
        public int CourierRating { get; set; }
        public string? CourierComment { get; set; }
    }
}
