using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Services = new HashSet<Service>();
        }

        public int InvoiceId { get; set; }
        public int? SpaId { get; set; }
        public int? CustomerId { get; set; }
        public int? PromotionId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Description { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Promotion? Promotion { get; set; }
        public virtual Spa? Spa { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
