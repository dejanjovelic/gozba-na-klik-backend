using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs
{
    public class RestaurantSortTypeOptionDto
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public RestaurantSortTypeOptionDto(RestaurantSortType restaurantSortType)
        {
            Key = (int)restaurantSortType;
            Name = restaurantSortType.ToString();
        }
    }
}
