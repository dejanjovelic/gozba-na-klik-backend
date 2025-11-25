using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
