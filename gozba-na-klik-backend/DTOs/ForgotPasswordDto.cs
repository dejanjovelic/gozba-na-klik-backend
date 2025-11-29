using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs
{
    public class ForgotPasswordDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string ResetUrlBase { get; set; }
    }
}
