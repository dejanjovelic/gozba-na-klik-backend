using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.MealDtos;
using System.ComponentModel.DataAnnotations;

namespace gozba_na_klik_backend.Services.DTOs.RestaurantDtos
{
    public class RestaurantWithMealsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double AverageRating { get; set; } = 5;
        public string? RestaurantImageUrl { get; set; }
        public List<MealDto>? MealsOnMenu { get; set; } = new List<MealDto>();
    }
}
