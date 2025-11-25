using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.DTOs
{
    public class RestaurantOrderDTO
    {
        public int OrderId { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime? OrderTime { get; set; }
        public int TotalQuantity { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
