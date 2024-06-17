using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
            Invoices = new HashSet<Invoice>();
            Reviews = new HashSet<Review>();
            IdCards = new HashSet<Card>();
        }

        public int IdCus { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Card> IdCards { get; set; }
    }
}
