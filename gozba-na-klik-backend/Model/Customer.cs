using gozba_na_klik_backend.Enum;

namespace gozba_na_klik_backend.Model
{
    public class Customer : User
    {
        public override Role Role => Role.Customer;
        public List<Allergens>? Allergens { get; set; } = new List<Allergens>();
        public List<Address>? Addresses { get; set; } = new List<Address>();
    }
}
