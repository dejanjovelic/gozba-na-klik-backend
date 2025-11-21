namespace gozba_na_klik_backend.Model
{
    public class RestaurantOwner
    {
        public string Id { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        List<Restaurant>? Restaurants { get; set; } = new List<Restaurant>();
    }
}
