using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Card
    {
        public Card()
        {
            Combos = new HashSet<Combo>();
            Customers = new HashSet<User>();
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string CardNumber { get; set; } = null!;
        public int CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }

        public virtual User Customer { get; set; } = null!;

        public virtual ICollection<Combo> Combos { get; set; }
        public virtual ICollection<User> Customers { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
