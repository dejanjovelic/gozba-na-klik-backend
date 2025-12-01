namespace gozba_na_klik_backend.DTOs
{
    public class CreateOrderReviewDTO
    {      
         public int OrderId { get; set; }
         public int RestaurantRating { get; set; }
         public string? RestaurantComment { get; set; }
         public string? RestaurantReviewImage { get; set; }
         public int CourierRating { get; set; }
         public string? CourierComment { get; set; }
    }
}
