using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.CourierDtos;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class CourierProfile : Profile
    {
        public CourierProfile()
        {
            CreateMap<Courier, CourierShortDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.ApplicationUser.UserName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ApplicationUser.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.ApplicationUser.Surname));
            CreateMap<Courier, NewCourierDto>();
        }
    }
}
