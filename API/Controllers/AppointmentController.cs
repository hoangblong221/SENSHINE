using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly SenShineSpaContext _dbContext;
        public AppointmentController(SenShineSpaContext dbContext)
        {
            this._dbContext = dbContext;
        }
        // //       GET: api/AllApointment
        //           [HttpGet]
        //            public async Task<ActionResult<IEnumerable<Appointment>>> GetAll()
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
        //        // GET: api/GetByAppointmentID lay ra danh sach cuoc hen theo ID
        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<Appointment>> GetAppointmentById(int IdAppointment)
        //        {
        //            var appointments = await _dbContext.Appointments.FindAsync(IdAppointment);

        //            if (appointments == null)
        //            {
        //                return NotFound();
        //            }

        //            return appointments;
        //        }

        //        // DELETE: api/Appoitnment xoa cuoc hen theo id 
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteAppointment(int IdAppointment)
        //        {
        //            var appointments = await _dbContext.Appointments.FindAsync(IdAppointment);
        //            if (appointments == null)
        //            {
        //                return NotFound();
        //            }

        //            _dbContext.Appointments.Remove(appointments);
        //            await _dbContext.SaveChangesAsync();

        //            return NoContent();
        //        }
    }
}