using gozba_na_klik_backend.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs
{
    public class UpdateOrderDTO
    {
        [Required]
        public OrderStatus NewStatus { get; set; }
        public DateTime NewTime { get; set; } = DateTime.UtcNow;
        public double PickupReadyIn { get; set; } = 0;
    }
}
