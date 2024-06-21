using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class PromotionMapper : Profile
    {
        public PromotionMapper()
        {
            CreateMap<Promotion, PromotionDTO>().ReverseMap();
            CreateMap<Promotion, PromotionDTORequest>().ReverseMap();
        }
    }

}
