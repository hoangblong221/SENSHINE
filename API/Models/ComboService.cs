using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ComboService
    {
        public int ComboId { get; set; }
        public int ServiceId { get; set; }
        public int Total { get; set; }

        public virtual Combo Combo { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
