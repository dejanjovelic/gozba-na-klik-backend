using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;
using System.Linq;

namespace gozba_na_klik_backend.Settings.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, RestaurantOrderDTO>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.ApplicationUser.Name + " " + src.Customer.ApplicationUser.Surname))
                .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.DeliveryAddress.Street + " " + src.DeliveryAddress.StreetNumber + ", " + src.DeliveryAddress.City))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src =>
                    src.OrderItems.Select(oi => new OrderItemDTO
                    {
                        MealName = oi.Meal.MealName,
                        MealPrice = oi.Meal.Price,
                        Quantity = oi.Quantity
                    }).ToList()));

            CreateMap<Order, CourierOrderDto>()
                    .ForMember(dest => dest.CustomerName, opt => 
                    opt.MapFrom(src => 
                    src.Customer.ApplicationUser.Name + " " + src.Customer.ApplicationUser.Surname))
                    .ForMember(dest => dest.Courier, opt => opt.MapFrom(src => src.Courier))
                    .ForMember(dest => dest.OrderItems, opt => opt.Ignore());

            CreateMap<Order, OrderDto>();

            CreateMap<Order, CustomerOrderResponseDto>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderTime.HasValue ? (DateOnly?)DateOnly.FromDateTime(src.OrderTime.Value) : null))
                .ForMember(dest => dest.RestaurantImageUrl, opt => opt.MapFrom(src => src.Restaurant.RestaurantImageUrl));

            CreateMap<Order, ResponseOrderDto>()
               .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
