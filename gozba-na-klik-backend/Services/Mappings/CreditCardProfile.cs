using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.DTOs;

namespace gozba_na_klik_backend.Services.Mappings
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile()
        {
            CreateMap<NewCreditCardDto, CreditCard>();
            CreateMap<CreditCard, CreditCardResponseDto>()
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => MaskCardNumber(src.CardNumber)));
        }

        private static string MaskCardNumber(string? number)
        {
            if (string.IsNullOrEmpty(number)) return string.Empty;
            int len = number.Length;
            if (len <= 4) return number;
            return new string('*', len - 4) + number.Substring(len - 4);
        }
    }
}
