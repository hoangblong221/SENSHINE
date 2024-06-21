using API.Dtos;
using API.Models;

namespace API.Services
{
    public interface IPromotionService
    {
        Task<Promotion> AddPromotion(PromotionDTO PromotionDto);
        Task<Promotion> EditPromotion(int id, PromotionDTO PromotionDto);
        Task<IEnumerable<PromotionDTORequest>> ListPromotion();
        Task<PromotionDTO> GetPromotionDetail(int id);
        Task<IEnumerable<PromotionDTORequest>> PromotionByCode(string code);
        Task<bool> DeletePromotion(int id);
    }
}
