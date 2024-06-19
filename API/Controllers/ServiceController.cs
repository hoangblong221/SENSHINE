using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly SenShineSpaContext _dbContext;
        private readonly ISpaService spaService;
        public ServiceController(SenShineSpaContext dbContext, ISpaService spaService)
        {
            this._dbContext = dbContext;
            this.spaService = spaService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ListOfServices = await spaService.GetAllServiceAsync();
            return View(ListOfServices);
        }
    }
}