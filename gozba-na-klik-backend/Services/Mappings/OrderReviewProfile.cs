using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs.Order;

namespace gozba_na_klik_backend.Services.Mappings
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
