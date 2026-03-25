using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class AddressProfile : Profile
    {
       public AddressProfile()
        {
            CreateMap<NewAddressDto, Address>();
        }
    }
}
