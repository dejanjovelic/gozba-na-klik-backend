using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Model
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }
        public string Bank { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty; // FK to Customer.Id, no navigation property

        public CardBrand Brand { get; set; } = CardBrand.Visa;

        public string CardHolderFirstName { get; set; } = string.Empty;
        public string CardHolderLastName { get; set; } = string.Empty;
    }
}
