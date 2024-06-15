using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Product
    {
        public Product()
        {
<<<<<<< HEAD
            SaleItems = new HashSet<SaleItem>();
=======
<<<<<<< HEAD
<<<<<<< HEAD
            SaleItems = new HashSet<SaleItem>();
=======
>>>>>>> 3c01c19a3da51403c8e5862e6ab2cada4a6bd574
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
=======
>>>>>>> 3c01c19a3da51403c8e5862e6ab2cada4a6bd574
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
            Categories = new HashSet<Category>();
        }

        public int ProductId { get; set; }
        public int? SpaId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityInStock { get; set; }

<<<<<<< HEAD
        public virtual Spa? Spa { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }

=======
<<<<<<< HEAD
<<<<<<< HEAD
        public virtual Spa? Spa { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }

=======
>>>>>>> 3c01c19a3da51403c8e5862e6ab2cada4a6bd574
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
=======
>>>>>>> 3c01c19a3da51403c8e5862e6ab2cada4a6bd574
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
        public virtual ICollection<Category> Categories { get; set; }
    }
}
