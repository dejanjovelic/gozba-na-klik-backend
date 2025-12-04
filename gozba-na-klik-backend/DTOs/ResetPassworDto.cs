using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs
{
    public class ResetPassworDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
