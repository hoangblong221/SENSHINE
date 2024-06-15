using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Room
    {
        public Room()
        {
            Appointments = new HashSet<Appointment>();
            Beds = new HashSet<Bed>();
        }

        public int RoomId { get; set; }
        public int? SpaId { get; set; }
        public string? RoomName { get; set; }
        public string? Status { get; set; }

        public virtual Spa? Spa { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Bed> Beds { get; set; }
    }
}
