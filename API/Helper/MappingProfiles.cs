using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Card, CardDTO>();
        }
    }
}
