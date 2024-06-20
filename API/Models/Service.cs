using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Service
    {
        public Service()
        {
            ComboServices = new HashSet<ComboService>();
            Reviews = new HashSet<Review>();
            Appointments = new HashSet<Appointment>();
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ComboService> ComboServices { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
