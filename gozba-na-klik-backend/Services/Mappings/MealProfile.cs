using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.MealDtos;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealWithAllergensDto>();
            CreateMap<Meal, MealDto>();
           
        }
    }
}
