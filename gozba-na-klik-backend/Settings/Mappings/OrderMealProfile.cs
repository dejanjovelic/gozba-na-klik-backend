using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings.Mappings
{
    public class OrderMealProfile : Profile
    {
        public OrderMealProfile()
        {
            CreateMap<OrderMeal, CourierOrderMealDto>()
                .ForMember(dest => dest.MealName, opt => opt.MapFrom(src => src.Meal.MealName));

            CreateMap<OrderMeal, OrderItemDTO>()
               .ForMember(dest => dest.MealName, opt => opt.MapFrom(src => src.Meal.MealName))
               .ForMember(dest => dest.MealPrice, opt => opt.MapFrom(src => src.Meal.Price))
               .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src=>src.Quantity));
        }
    }
}
