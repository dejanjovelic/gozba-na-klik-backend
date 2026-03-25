using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.RestaurantDtos;

namespace gozba_na_klik_backend.Services.Mappings
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
