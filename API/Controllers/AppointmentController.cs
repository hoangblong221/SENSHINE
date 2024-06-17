//sing API.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace API.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class AppointmentController : Controller
//    {
//        private readonly SpaProjectContext _dbContext;
//        public AppointmentController(SpaProjectContext dbContext)
//        {
//            this._dbContext = dbContext;
//        }
//        // GET: api/AllApointment
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Appointment>>> GetAll()
//        {
//            try
//            {
//                var appointments = await _dbContext.Appointments.ToListAsync();
//                return Ok(appointments);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"Failed to retrieve appointments: {ex.Message}");
//            }
//        }
//        // GET: api/GetByAppointmentID
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Appointment>> GetAppointmentById (int AppointmentID)
//        {
//            var appointments = await _dbContext.Appointments.FindAsync(AppointmentID);

//            if (appointments == null)
//            {
//                return NotFound();
//            }

//            return appointments;
//        }
//    }
//}
