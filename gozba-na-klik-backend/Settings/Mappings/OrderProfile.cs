using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, RestaurantOrderDTO>()
                    .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name))
                    .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
                    .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src =>
                        src.Customer.Addresses.FirstOrDefault() != null
                            ? src.Customer.Addresses.FirstOrDefault().Street + ", " + src.Customer.Addresses.FirstOrDefault().City
                            : string.Empty))
                    .ForMember(dest => dest.TotalQuantity, opt => opt.MapFrom(src =>
                        src.OrderItems.Sum(oi => oi.Quantity)))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                    .ForMember(dest => dest.OrderTime, opt => opt.MapFrom(src => src.OrderTime));

            CreateMap<Order, CourierOrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
            .ForMember(dest => dest.OrderItems, opt => opt.Ignore());

            CreateMap<Order, OrderDto>();

        }
    }
}
