using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


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
            return _context.Cards.Include(c => c.Customer).Include(s => s.IdSers).ToList();
        }

        public Card GetCard(int id)
        {
            return _context.Cards.Include(c => c.Customer).Include(s => s.IdSers).Where(c => c.IdCard == id).FirstOrDefault();
        }

        public ICollection<Card> GetCardNumNamePhone(string input)
        {
            return _context.Cards.Include(c => c.Customer).Include(s => s.IdSers).Where(c => c.CardNumber.Contains(input)
            || c.Customer.Name.Contains(input)
            || c.Customer.Phone.Contains(input)).ToList();
        }

        public ICollection<Card> SortCardByDate(string dateFrom, string dateTo)
        {
            DateTime parsedDateFrom = ParseDateTimeLikeSSMS(dateFrom);
            DateTime parsedDateTo = ParseDateTimeLikeSSMS(dateTo);

            return _context.Cards.Where(c => c.CreateDate <= parsedDateTo
                                          && c.CreateDate >= parsedDateFrom).ToList();
        }

        public bool CardExist(int id)
        {
            return _context.Cards.Any(c => c.IdCard == id);
        }

        public bool CardExistNumNamePhone(string input)
        {
            return _context.Cards.Any(c => c.CardNumber.Contains(input)
            || c.Customer.Name.Contains(input)
            || c.Customer.Phone.Contains(input));
        }

        public bool CardExistByDate(string dateFrom, string dateTo)
        {
            DateTime parsedDateFrom = ParseDateTimeLikeSSMS(dateFrom);
            DateTime parsedDateTo = ParseDateTimeLikeSSMS(dateTo);

            return _context.Cards.Any(c => c.CreateDate <= parsedDateTo
                                        && c.CreateDate >= parsedDateFrom);
        }

        public static DateTime ParseDateTimeLikeSSMS(string dateString)
        {
            string format = "yyyy-MM-dd'T'HH:mm:ss"; // Adjust format based on your string
            DateTime convertedDateTime;
            convertedDateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            return convertedDateTime;
        }
    }
}
