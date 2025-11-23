using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.DTOs
{
    public class CreateCustomerDto
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
