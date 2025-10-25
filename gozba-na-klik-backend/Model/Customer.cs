namespace gozba_na_klik_backend.Model
{
    public class Customer : User
    {
        public override Role Role => Role.Customer;
        public List<Allergen>? Allergens { get; set; } = new List<Allergen>();
        public List<Address>? Addresses { get; set; } = new List<Address>();
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
