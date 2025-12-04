using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings.Mappings
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantWithMealsDto>()
                .ForMember(dest => dest.MealsOnMenu, opt => opt.MapFrom(src => src.MealsOnMenu));

            CreateMap<Restaurant, RestaurantDto>();
        }
    }
}
