using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int? SpaId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string? TransactionType { get; set; }
        public string? Description { get; set; }

        public virtual User? Customer { get; set; }
        public virtual Spa? Spa { get; set; }
    }
}
