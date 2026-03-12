using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;
using Microsoft.AspNetCore.Identity;

namespace gozba_na_klik_backend.Services.Mappings
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
