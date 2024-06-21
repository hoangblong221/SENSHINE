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
        }
    }
}
