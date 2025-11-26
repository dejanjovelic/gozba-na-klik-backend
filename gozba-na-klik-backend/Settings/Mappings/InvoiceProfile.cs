using AutoMapper;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Order, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerName,
                opt => opt.MapFrom(src => src.Customer.ApplicationUser.Name))
                .ForMember(dest => dest.CustomerSurname,
                opt => opt.MapFrom(src => src.Customer.ApplicationUser.Surname))

                .ForMember(dest => dest.DeliveryFullAddress, opt => opt.MapFrom(
                    src => src.DeliveryAddress.Street + " "
                    + src.DeliveryAddress.StreetNumber + "; "
                    + src.DeliveryAddress.ZipCode + " "
                    + src.DeliveryAddress.City))
                .ForMember(dest => dest.CourierName,
                opt => opt.MapFrom(src => src.Courier.ApplicationUser.Name))
                .ForMember(dest => dest.CourierSurname,
                opt => opt.MapFrom(src => src.Courier.ApplicationUser.Surname))
                .ForMember(dest => dest.OrderedMeals,
                opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}
