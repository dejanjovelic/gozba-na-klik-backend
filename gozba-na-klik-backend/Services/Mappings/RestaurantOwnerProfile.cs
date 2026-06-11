using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.RestaurantOwnerDtos;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class RestaurantOwnerProfile : Profile
    {
        public RestaurantOwnerProfile()
        {
            CreateMap<RestaurantOwner, CreateRestaurantOwnerDto>();

            CreateMap<RestaurantOwner, RestaurantOwnerShortResponseDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ApplicationUser.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.ApplicationUser.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email));
        }
    }
}
