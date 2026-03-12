using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class RestauranOwnerProfile : Profile
    {
        public RestauranOwnerProfile()
        {
            CreateMap<RestaurantOwner, NewRestaurantOwnerDto>();
        }
    }
}
