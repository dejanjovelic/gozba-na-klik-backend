using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs
{
    public class CourierOrderDto
    {

        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerName { get; set; }
        public CourierShortDto? Courier { get; set; }
        public Address DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime? OrderTime { get; set; }
        public List<CourierOrderMealDto> OrderItems { get; set; } = new List<CourierOrderMealDto>();

    }
}
