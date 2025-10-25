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
        public TimeSpan? OrderTime { get; set; }
        public int TotalQuantity { get; set; }
    }
}
