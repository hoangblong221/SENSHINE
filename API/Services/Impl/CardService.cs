using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using API.Ultils;
using API.Dtos;
using AutoMapper;


namespace API.Services.Impl
{
    public class CardService : ICardService
    {
        private readonly SenShineSpaContext _context;
        private readonly IMapper _mapper;

        public CardService(SenShineSpaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public ICollection<Card> GetCards()
        {
            return _context.Cards.Include(c => c.Customer).Include(s => s.Combos).ToList();
        }

        public Card GetCard(int id)
        {
            return _context.Cards.Include(c => c.Customer).Include(s => s.Combos).Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<CardDTO> GetCardNumNamePhone(string input)
        {
            input = input.ToLower();
            var cards = _mapper.Map<List<CardDTO>>(_context.Cards.Include(c => c.Customer).Include(s => s.Combos));
            return cards.Where(c => c.CardNumber.ToLower().Contains(input)
                                 || c.CustomerName.ToLower().Contains(input)
                                 || c.Phone.Contains(input)).ToList();
        }

        public ICollection<Card> SortCardByDate(string dateFrom, string dateTo)
        {
            DateTime parsedDateFrom = FormatDateTimeUtils.ParseDateTimeLikeSSMS(dateFrom);
            DateTime parsedDateTo = FormatDateTimeUtils.ParseDateTimeLikeSSMS(dateTo);

            return _context.Cards.Include(c => c.Customer).Include(s => s.Combos).Where(c => c.CreateDate >= parsedDateFrom
                                                                                          && c.CreateDate <= parsedDateTo).ToList();
        }

        public bool CardExist(int id)
        {
            return _context.Cards.Any(c => c.Id == id);
        }

        public bool CardExistNumNamePhone(string input)
        {
            input = input.ToLower();
            var cards = _mapper.Map<List<CardDTO>>(_context.Cards.Include(c => c.Customer).Include(s => s.Combos));
            return cards.Any(c => c.CardNumber.ToLower().Contains(input)
                               || c.CustomerName.ToLower().Contains(input)
                               || c.Phone.Contains(input));
        }

        public bool CardExistByDate(string dateFrom, string dateTo)
        {
            DateTime parsedDateFrom = FormatDateTimeUtils.ParseDateTimeLikeSSMS(dateFrom);
            DateTime parsedDateTo = FormatDateTimeUtils.ParseDateTimeLikeSSMS(dateTo);

            return _context.Cards.Any(c => c.CreateDate <= parsedDateTo
                                        && c.CreateDate >= parsedDateFrom);
        }

        public bool CreateCard(int CustomerId, ICollection<int> ComboId, Card card)
        {
            var customer = _context.Users.Where(u => u.Id == CustomerId).FirstOrDefault();

            var comboList = new List<Combo>();

            foreach (int id in ComboId)
            {
                var combo = _context.Combos.Where(c => c.Id == id).FirstOrDefault();
                comboList.Add(combo);
            }

            card = new Card()
            {
                CustomerId = customer.Id,
                Combos = comboList,
            };

            _context.Add(card);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
