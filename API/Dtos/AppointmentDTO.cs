using API.Models;

namespace API.Dtos
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public int? SpaId { get; set; }
        public int? RoomId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ServiceId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public TimeSpan? AppointmentTime { get; set; }
        public string? Status { get; set; }

        public virtual User? Customer { get; set; }
        public virtual User? Employee { get; set; }
        public virtual Room? Room { get; set; }
        public virtual Service? Service { get; set; }
        public virtual Spa? Spa { get; set; }
    }
}
