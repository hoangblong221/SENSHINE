using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Web.Models;

namespace Web.Controllers
{
    public class ServiceController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5297/api");
        private readonly HttpClient _httpClient;
        public ServiceController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            List<ServiceViewModel> servicesList = new List<ServiceViewModel>();
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/Service/GetAllServices");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                servicesList = JsonConvert.DeserializeObject<List<ServiceViewModel>>(data);
            }
            return View(servicesList);
        }

        // GET: Service/Details/{id}
        [HttpGet]
        public async Task<IActionResult> ServiceDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID Service không hợp lệ");
            }

            ServiceViewModel service = null;
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/Service/GetByID?IdSer={id}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                service = JsonConvert.DeserializeObject<ServiceViewModel>(data);
            }

            if (service == null)
            {
                return NotFound("Không tìm thấy dịch vụ");
            }

            return View(service);
        }
        // GET: Service/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public async Task<IActionResult> CreateService(ServiceViewModel service)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(service);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"/Service/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ServiceList");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the service.");
                    return View(service);
                }
            }

            return View(service);
        }
    }
}