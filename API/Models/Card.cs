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

        public virtual ICollection<Customer> IdCus { get; set; }
        public virtual ICollection<Service> IdSers { get; set; }
    }
}
