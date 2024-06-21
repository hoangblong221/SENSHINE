using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using API.Ultils;


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
            return _context.Cards.Include(c => c.Customer).Include(s => s.Combos).ToList();
        }

        public Card GetCard(int id)
        {
            return _context.Cards.Include(c => c.Customer).Include(s => s.Combos).Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Card> GetCardNumNamePhone(string input)
        {
            return _context.Cards.Include(c => c.Customer).Include(s => s.Combos).Where(c => c.CardNumber.Contains(input)
                                                                                            || c.Customer.FirstName.Contains(input)
                                                                                            || c.Customer.MidName.Contains(input)
                                                                                            || c.Customer.LastName.Contains(input)
                                                                                            || c.Customer.Phone.Contains(input)).ToList();
        }

        public ICollection<Card> SortCardByDate(string dateFrom, string dateTo)
        {
            DateTime parsedDateFrom = FormatDateTimeUtils.ParseDateTimeLikeSSMS(dateFrom);
            DateTime parsedDateTo = FormatDateTimeUtils.ParseDateTimeLikeSSMS(dateTo);

            return _context.Cards.Include(c => c.Customer).Include(s => s.Combos).Where(c => c.CreateDate <= parsedDateTo
                                                                                          && c.CreateDate >= parsedDateFrom).ToList();
        }

        public bool CardExist(int id)
        {
            return _context.Cards.Any(c => c.Id == id);
        }

        public bool CardExistNumNamePhone(string input)
        {
            return _context.Cards.Any(c => c.CardNumber.Contains(input)
                                        || c.Customer.FirstName.Contains(input)
                                        || c.Customer.MidName.Contains(input)
                                        || c.Customer.LastName.Contains(input)
                                        || c.Customer.Phone.Contains(input));
        }

        public bool CardExistByDate(string dateFrom, string dateTo)
        {
            DateTime parsedDateFrom = FormatDateTimeUtils.ParseDateTimeLikeSSMS(dateFrom);
            DateTime parsedDateTo = FormatDateTimeUtils.ParseDateTimeLikeSSMS(dateTo);

            return _context.Cards.Any(c => c.CreateDate <= parsedDateTo
                                        && c.CreateDate >= parsedDateFrom);
        }
    }
}
