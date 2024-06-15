using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Asset
    {
        public int AssetId { get; set; }
        public int? SpaId { get; set; }
        public string? AssetName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Value { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }

        public virtual Spa? Spa { get; set; }
    }
}
