using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class AllergenProfile : Profile
    {
        public AllergenProfile()
        {
            CreateMap<Allergen, AllergenWithFlagDto>()
               .ForMember(dest => dest.IsCustomerAllergen,
               otp => otp.Ignore()
               );
        }
    }
}
