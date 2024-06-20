using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class NewsMapper : Profile
    {
        public NewsMapper()
        {
            CreateMap<News, NewsDTO>().ReverseMap();
            CreateMap<News, NewsDTORequest>()
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate.ToString("yyyy/MM/dd"))).ReverseMap();
        }
    }
}