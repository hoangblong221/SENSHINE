using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Products = new HashSet<Product>();
            Services = new HashSet<Service>();
        }

        public int IdAppointment { get; set; }
        public int CustomerId { get; set; }
        public int IdEmployee { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee IdEmployeeNavigation { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
