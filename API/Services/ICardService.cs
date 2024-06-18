using API.Models;

namespace API.Services
{
    public interface ICardService
    {
        ICollection<Card> GetCards();
        Card GetCard(int id);
        ICollection<Card> GetCardNum(string num);
        String GetCustomerName(int id);
        bool CardExist(int id);
        bool CardExistNum(string num);
    }
}
