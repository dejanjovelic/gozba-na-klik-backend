using gozba_na_klik_backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.DTOs
{
    public class UpdateOrderDTO
    {
        public OrderStatus NewStatus { get; set; }
        public DateTime? NewTime { get; set; }
    }
}
