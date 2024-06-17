using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Service
    {
        public Service()
        {
            Reviews = new HashSet<Review>();
            Appointments = new HashSet<Appointment>();
            IdCards = new HashSet<Card>();
            Invoices = new HashSet<Invoice>();
        }

        public int IdSer { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Card> IdCards { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
