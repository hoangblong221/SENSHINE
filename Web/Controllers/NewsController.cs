using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Web.Models;
namespace Web.Controllers
{
    public class NewsController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5297/api");
        private readonly HttpClient _httpClient;
        public NewsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public async Task<IActionResult> NewsList()
        {
            List<NewsViewModel> viewList = new List<NewsViewModel>();
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/ListAllNews");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                viewList = JsonConvert.DeserializeObject<List<NewsViewModel>>(data);
            }
            return View(viewList);
        }
        public IActionResult AddNews()
        {
            return View();
        }

    }
}
