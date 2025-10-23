using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealWithAllergensDto>();

            CreateMap<Allergen, AllergenWithFlagDto>()
                .ForMember(dest => dest.IsCustomerAllergen,
                otp => otp.Ignore()
                );
        }
    }
}
