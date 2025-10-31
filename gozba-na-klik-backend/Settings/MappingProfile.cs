using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Meal, MealDto>();

            CreateMap<Restaurant, RestaurantWithMealsDto>()
                .ForMember(dest => dest.MealsOnMenu, opt => opt.MapFrom(src => src.MealsOnMenu));
        }
    }
}
