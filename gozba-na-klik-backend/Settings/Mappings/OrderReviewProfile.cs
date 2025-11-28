using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Settings.Mappings
{
    public class OrderReviewProfile : Profile
    {
        public OrderReviewProfile()
        {
            CreateMap<CreateOrderReviewDTO, OrderReview>();
        }
    }
}
