using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings.Mappings
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
