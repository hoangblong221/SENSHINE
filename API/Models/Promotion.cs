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
<<<<<<< HEAD

        public virtual Spa? Spa { get; set; }
=======
<<<<<<< HEAD

        public virtual Spa? Spa { get; set; }
=======
>>>>>>> 3c01c19a3da51403c8e5862e6ab2cada4a6bd574
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
    }
}
