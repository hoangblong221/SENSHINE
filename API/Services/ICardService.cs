using API.Models;

namespace API.Services
{
    public interface ICardService
    {
        ICollection<Card> GetCards();
    }
}
