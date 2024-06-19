using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Card
    {
        public Card()
        {
            IdCus = new HashSet<Customer>();
            IdSers = new HashSet<Service>();
        }

        public int IdCard { get; set; }
        public string CardNumber { get; set; } = null!;
        public int CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<Customer> IdCus { get; set; }
        public virtual ICollection<Service> IdSers { get; set; }
    }
}
