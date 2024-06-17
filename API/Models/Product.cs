using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Product
    {
        public Product()
        {
            Appointments = new HashSet<Appointment>();
            Categories = new HashSet<Category>();
            IdImgs = new HashSet<Image>();
        }

        public int IdProduct { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal? Price { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Image> IdImgs { get; set; }
    }
}
