namespace gozba_na_klik_backend.DTOs
{
    public class NewAddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
