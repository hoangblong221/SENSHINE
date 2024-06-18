using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        public IActionResult GetCards()
        {
            var cards = _mapper.Map<List<CardDTO>>(_cardService.GetCards());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cards);
        }

        [HttpGet("{id}/byId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        [ProducesResponseType(400)]
        public IActionResult GetCard(int id)
        {
            if(!_cardService.CardExist(id))
                return NotFound();

            var card = _mapper.Map<CardDTO>(_cardService.GetCard(id));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(card);
        }

        [HttpGet("{num}/byNum")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        [ProducesResponseType(400)]
        public IActionResult GetCardsByNum(string num)
        {
            if (!_cardService.CardExistNum(num))
                return NotFound();

            var cards = _mapper.Map<List<CardDTO>>(_cardService.GetCardNum(num));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cards);
        }

        [HttpGet("{id}/customerName")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerName(int id)
        {
            if (!_cardService.CardExist(id))
                return NotFound();

            var cusName = _cardService.GetCustomerName(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cusName);
        }
    }
}
