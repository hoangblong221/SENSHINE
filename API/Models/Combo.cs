using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Combo
    {
        public Combo()
        {
            ComboServices = new HashSet<ComboService>();
            Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        public string? Note { get; set; }
        public decimal SalePrice { get; set; }
        public decimal? OriginalPrice { get; set; }

        public virtual ICollection<ComboService> ComboServices { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}