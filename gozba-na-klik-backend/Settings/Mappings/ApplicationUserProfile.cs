using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using Microsoft.AspNetCore.Identity;

namespace gozba_na_klik_backend.Settings.Mappings
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<RegistrationDto, ApplicationUser>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUser, ProfileDTO>();
            CreateMap<ApplicationUser, UpdateImageDto>();
        }
    }
}
