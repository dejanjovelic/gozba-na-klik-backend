using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.NonWorkingDateDtos;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class NonWorkingDateProfile : Profile
    {
        public NonWorkingDateProfile()
        {
            CreateMap<NonWorkingDate, NonWorkingDateResponseDto>();
            CreateMap<CreateNonWorkingDateDto, NonWorkingDate>();
        }
    }
}
