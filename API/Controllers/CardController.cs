using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;
        public CardController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        public async Task<IActionResult> GetCards()
        {
            var cards = _mapper.Map<List<CardDTO>>(_cardService.GetCards());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cards);
        }

        //[HttpGet("{id}/byId")]
        ////[ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        ////[ProducesResponseType(400)]
        //public IActionResult GetCard(int id)
        //{
        //    if(!_cardService.CardExist(id))
        //        return NotFound();

        //    var card = _mapper.Map<CardDTO>(_cardService.GetCard(id));

        //    if(!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    return Ok(card);
        //}

        [HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        //[ProducesResponseType(400)]
        public async Task<IActionResult> GetCardsByNumNamePhone(string input)
        {
            if (!_cardService.CardExistNumNamePhone(input))
                return NotFound();

            var cards = _mapper.Map<List<CardDTO>>(_cardService.GetCardNumNamePhone(input));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cards);
        }

        [HttpGet]
        public async Task<IActionResult> SortCardByDate(string dateFrom, string dateTo)
        {
            if (!_cardService.CardExistByDate(dateFrom, dateTo))
                return NotFound();

            var cards = _mapper.Map<List<CardDTO>>(_cardService.SortCardByDate(dateFrom, dateTo));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cards);
        }
    }
}
