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

            CreateMap<Restaurant, RestaurantShortenDto>();

            CreateMap<CreateRestaurantDto, Restaurant>();
            CreateMap<UpdateRestaurantDto, Restaurant>()
                .ForMember(dest => dest.WorkingHours, opt => opt.Ignore())
                .ForMember(dest => dest.NonWorkingDates, opt => opt.Ignore());

            CreateMap<Restaurant, RestaurantWithWorkingHoursAndNonWokingDaysDto>();
        }
    }
}
