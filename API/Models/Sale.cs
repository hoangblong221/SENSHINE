using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SaleItems = new HashSet<SaleItem>();
        }

        public int SaleId { get; set; }
        public int? SpaId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentStatus { get; set; }

        public virtual User? Customer { get; set; }
        public virtual Spa? Spa { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }
    }
}
