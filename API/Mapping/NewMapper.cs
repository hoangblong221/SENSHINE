using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class NewMapper : Profile
    {
        public NewMapper()
        {   //News Automapper
            CreateMap<News, NewsDTO>().ReverseMap();
            CreateMap<News, NewsDTORequest>()
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate.ToString("yyyy/MM/dd"))).ReverseMap();

            //Promotions Automapper
            CreateMap<Promotion, PromotionDTO>().ReverseMap();
            CreateMap<Promotion, PromotionDTORequest>().ReverseMap();

            //Card Automapper
            CreateMap<Card, CardDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.MidName + " " + src.Customer.LastName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Customer.Phone))
                .ForMember(dest => dest.ComboName, opt => opt.MapFrom(src => src.Combos.Select(s => s.Name).ToList()))
                .ForMember(dest => dest.InvoiceId, opt => opt.MapFrom(src => src.Invoices.Select(s => s.Id).ToList()));
            CreateMap<CardDTO, Card>();
        }
    }
}
