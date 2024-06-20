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
        public async Task<IActionResult> GetAllServices()
        {
            var ListOfServices = await spaService.GetAllServiceAsync();
            return Ok(ListOfServices);
        }

        [HttpGet]
        public async Task<IActionResult> GetByID(int IdSer)
        {
            if (IdSer < 1)
            {
                return BadRequest("ID Service không tồn tại");
            }
            else
            {
                var service = await spaService.FindServiceWithItsId(IdSer);
                if (service == null)
                {
                    return NotFound("Service không tồn tại");
                }
                return Ok(service);
            }
        }

    }
}