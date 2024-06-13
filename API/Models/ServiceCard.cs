using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ServiceCard
    {
        public int ServiceCardId { get; set; }
        public int? SpaId { get; set; }
        public int? ServiceId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Status { get; set; }

        public virtual User? Customer { get; set; }
        public virtual Service? Service { get; set; }
        public virtual Spa? Spa { get; set; }
    }
}
