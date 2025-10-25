using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public double AverageRating { get; set; } = 5;
        public string? RestaurantImageUrl { get; set; }
        [Required]
        public int RestaurantOwnerId { get; set; }
        public User? RestaurantOwner { get; set; }
        public List<Meal>? MealsOnMenu { get; set; } = new List<Meal>();
        public List<WorkingHours>? WorkingHours { get; set; } = new List<WorkingHours>();
        public List<NonWorkingDate>? NonWorkingDates { get; set; } = new List<NonWorkingDate>();
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
