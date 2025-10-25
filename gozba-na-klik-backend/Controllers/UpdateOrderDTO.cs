using gozba_na_klik_backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    public class UpdateOrderDTO
    {
        public OrderStatus NewStatus { get; set; }
        public TimeSpan NewTime { get; set; }
    }
}
