using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Promotion
    {
        public int PromotionId { get; set; }
        public int? SpaId { get; set; }
        public string? PromotionName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public decimal? DiscountPercentage { get; set; }

        public virtual Spa? Spa { get; set; }
    }
}
