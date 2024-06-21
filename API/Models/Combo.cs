using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Combo
    {
        public Combo()
        {
            Cards = new HashSet<Card>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? SalePrice { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
