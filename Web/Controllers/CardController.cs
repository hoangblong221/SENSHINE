//using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using Web.Models;

namespace Web.Controllers
{
    public class CardController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5297/api");
        private readonly HttpClient _client;

        public CardController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index(string searchInput)
        {
            List<CardViewModel> Cards = new List<CardViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Card/GetCards").Result;

            if (!string.IsNullOrEmpty(searchInput))
            {
                response = _client.GetAsync(_client.BaseAddress + "/Card/GetCardsByNumNamePhone?input=" + searchInput).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Cards = JsonConvert.DeserializeObject<List<CardViewModel>>(data);
            }

            return View(Cards);
        }

    }
}