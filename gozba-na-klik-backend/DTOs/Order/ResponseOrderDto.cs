namespace gozba_na_klik_backend.DTOs.Order
{
    public class ResponseOrderDto
    {
        public int OrderId { get; set; }
        public bool RequiresAllergenWarn { get; set; }
        public double TotalPrice { get; set; }
    }
}
