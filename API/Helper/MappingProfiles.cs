using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Card, CardDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Customer.Phone))
            .ForMember(dest => dest.ServiceNames, opt => opt.MapFrom(src => src.IdSers.Select(s => s.ServiceName).ToList()));
        }
    }
}
