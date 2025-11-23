using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.DTOs
{
    public class ApplicationUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
