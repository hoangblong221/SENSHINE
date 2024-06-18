using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Spa
    {
        public Spa()
        {
            Invoices = new HashSet<Invoice>();
            Promotions = new HashSet<Promotion>();
            IdRooms = new HashSet<Room>();
        }

        public int IdSpa { get; set; }
        public string SpaName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }

        public virtual ICollection<Room> IdRooms { get; set; }
    }
}
