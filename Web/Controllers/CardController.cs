using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using Web.Models;
using API.Ultils;
using System.Text;

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
        public async Task<IActionResult> Index(string searchInput, DateTime? dateFrom, DateTime? dateTo)
        {
            List<CardViewModel> Cards = new List<CardViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Card/GetCards").Result;

            if (dateFrom.HasValue && dateTo.HasValue)
            {
                response = _client.GetAsync(_client.BaseAddress + "/Card/SortCardByDate?dateFrom=" + dateFrom.Value.ToString("yyyy-MM-dd") + "&dateTo=" + dateTo.Value.ToString("yyyy-MM-dd")).Result;
            }

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

        [HttpPost]
        public async Task<IActionResult> CreateCard(string cardNumber, DateTime? createDate, string status, decimal totalPrice, int customerId, List<int> comboId)
        {
            CardCreateModel card = new CardCreateModel()
            {
                CardNumber = cardNumber,
                CreateDate = createDate,
                Status = status,
                TotalPrice = totalPrice,
            };

            string comboIdList = "";

            foreach (var item in comboId)
            {
                comboIdList = comboIdList + "&ComboId=" + item.ToString();
            }

            string data = "?CardNumber=" + cardNumber + "&CreateDate=" + createDate + "&Status=" + status + "&TotalPrice=" + totalPrice + "&CustomerId=" + customerId + "&ComboId=" + comboIdList;

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + "/Card/CreateCard", content);

            return Ok(response);
        }
    }
}