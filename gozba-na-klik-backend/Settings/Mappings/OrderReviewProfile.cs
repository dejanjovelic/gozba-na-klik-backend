using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.DTOs.Order;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings.Mappings
{
    public class OrderReviewProfile : Profile
    {
        public OrderReviewProfile()
        {
            CreateMap<CreateOrderReviewDTO, OrderReview>();

            CreateMap<OrderReview, OrderReviewResponseDto>()
                .ForMember(dest => dest.CustomerName,
                           opt => opt.MapFrom(src => src.Order.Customer.ApplicationUser.Name));
        }
    }
}
