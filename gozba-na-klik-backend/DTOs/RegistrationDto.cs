using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs
{
    public class RegistrationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        public string? ProfileImageUrl { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
               
    }
}
