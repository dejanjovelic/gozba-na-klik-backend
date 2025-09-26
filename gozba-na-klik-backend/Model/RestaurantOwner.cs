using gozba_na_klik_backend.Enum;

namespace gozba_na_klik_backend.Model
{
    public class RestaurantOwner: User
    {
        public override Role Role => Role.RestaurantOwner;
        List<Restaurant> Restaurants { get; set; }

    }
}
