using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class NewsMapper : Profile
    {
        public NewsMapper()
        {
            CreateMap<Card, CardDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.MidName + " " + src.Customer.LastName))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Customer.Phone))
            .ForMember(dest => dest.ComboName, opt => opt.MapFrom(src => src.Combos.Select(s => s.Name).ToList()));
        }
    }
}
