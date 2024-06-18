using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        public IActionResult GetCards()
        {
            var cards = _cardService.GetCards();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cards);
        }
    }
}
