using API.Models;
using System.Reflection.Metadata.Ecma335;

namespace API.Services.Impl
{
    public class CardService : ICardService
    {
        private readonly SenShineSpaContext _context;

        public CardService(SenShineSpaContext context)
        {
            _context = context;
        }

        public ICollection<Card> GetCards()
        {
            return _context.Cards.OrderBy(c => c.IdCard).ToList();
        }
    }
}
