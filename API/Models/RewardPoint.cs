using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class RewardPoint
    {
        public int RewardId { get; set; }
        public int? CustomerId { get; set; }
        public int? Points { get; set; }
        public DateTime? DateEarned { get; set; }
        public DateTime? DateRedeemed { get; set; }

        public virtual User? Customer { get; set; }
    }
}
