using API.Models;

namespace API.Services
{
    public interface ICardService
    {
        ICollection<Card> GetCards();
        Card GetCard(int id);
        ICollection<Card> GetCardNumNamePhone(string input);
        ICollection<Card> SortCardByDate(string dateFrom, string dateTo);
        bool CardExist(int id);
        bool CardExistNumNamePhone(string input);
        bool CardExistByDate(string dateFrom, string dateTo);
    }
}
