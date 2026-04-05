using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double AverageRating { get; set; } = 0;
        public string? RestaurantImageUrl { get; set; }
        public bool IsCreated { get; set; }
        public string RestaurantOwnerId { get; set; }

        public List<Meal>? MealsOnMenu { get; set; } = new List<Meal>();
        public List<WorkingHours>? WorkingHours { get; set; } = new List<WorkingHours>();
        public List<NonWorkingDate>? NonWorkingDates { get; set; } = new List<NonWorkingDate>();
        public List<Order>? Orders { get; set; } = new List<Order>();

    }
}
