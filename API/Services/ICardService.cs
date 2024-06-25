using API.Dtos;
using API.Models;

namespace API.Services
{
    public interface ICardService
    {
        ICollection<Card> GetCards();
        Card GetCard(int id);
        Combo GetCombo(int id);
        ICollection<CardDTO> GetCardNumNamePhone(string input);
        ICollection<Card> SortCardByDate(string dateFrom, string dateTo);
        bool CardExist(int id);
        bool CardExistNumNamePhone(string input);
        bool CardExistByDate(string dateFrom, string dateTo);
        Task<Card> CreateCard(Card card);
        Task<Card> UpdateCard(int id, Card card);
        Task<Card> ActiveDeactiveCard(int id);
    }
}
