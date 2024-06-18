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

        public Card GetCard(int id)
        {
            return _context.Cards.Where(c => c.IdCard == id).FirstOrDefault();
        }

        public ICollection<Card> GetCardNum(string num)
        {
            return _context.Cards.Where(c => c.CardNumber.Contains(num)).ToList();
        }

        public string GetCustomerName(int id)
        {
            var Card = _context.Cards.Where(c => c.IdCard == id).FirstOrDefault();
            var Customer = _context.Customers.Where(c => c.IdCards.Contains(Card));

            if (Customer.Count() <= 0)
                return "Not found";
            else
                return Customer.Single().Name;
        }

        public ICollection<Card> GetCards()
        {
            return _context.Cards.OrderBy(c => c.IdCard).ToList();
        }

        public bool CardExist(int id)
        {
            return _context.Cards.Any(c => c.IdCard == id);
        }
        public bool CardExistNum(string num)
        {
            return _context.Cards.Any(c => c.CardNumber.Contains(num));
        }
    }
}
