using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        //public async Task<IActionResult> ServiceDetails(int IdSer)
        //{
        //    try
        //    {
        //        HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/Service/GetById/{IdSer}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string data = await response.Content.ReadAsStringAsync();
        //            ServiceDetails service = JsonConvert.DeserializeObject<ServiceViewModel>(data);

        //            // Hiển thị view với thông tin chi tiết sản phẩm
        //            return View(service);
        //        }
        //        else
        //        {
        //            // Xử lý trường hợp không tìm thấy sản phẩm
        //            TempData["errorMessage"] = $"Not found Service with id {IdSer}";
        //            return View();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý trường hợp gặp lỗi
        //        TempData["errorMessage"] = ex.Message;
        //        return View();
        //    }
        //}
    }
}