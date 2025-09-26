namespace gozba_na_klik_backend.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int RestaurantOwnerId { get; set; }
        public User RestaurantOwner { get; set; }
        public List<Meal> MealsOnMenu { get; set; }
        public List<WorkingHours> WorkingHours {  get; set; }
        List<NonWorkingDate> nonWorkingDates { get; set; }

    }
}
