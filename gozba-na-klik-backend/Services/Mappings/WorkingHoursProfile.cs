using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.WorkingHoursDtos;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class WorkingHoursProfile : Profile
    {
        public WorkingHoursProfile()
        {
            CreateMap<WorkingHours, WorkingHoursDto>();
            CreateMap<UpdateWorkingHoursDto, WorkingHours>();
        }
    }
}
