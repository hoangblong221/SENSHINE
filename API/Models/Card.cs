using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Card
    {
        public Card()
        {
            Customers = new HashSet<User>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string CardNumber { get; set; } = null!;
        public int CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }

        public virtual User Customer { get; set; } = null!;

        public virtual ICollection<User> Customers { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
