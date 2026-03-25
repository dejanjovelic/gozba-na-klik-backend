using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Services.DTOs
{
    public class NewCreditCardDto
    {
        public int Id { get; set; }
        public string Bank { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public CardBrand Brand { get; set; } = CardBrand.Visa;
        public string CardHolderFirstName { get; set; } = string.Empty;
        public string CardHolderLastName { get; set; } = string.Empty;
    }
}
