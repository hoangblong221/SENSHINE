using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController: Controller
    {
        Uri baseAddress = new Uri("http://localhost:5297");
        private readonly HttpClient _httpClient;
        public ServiceController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

    }
}
