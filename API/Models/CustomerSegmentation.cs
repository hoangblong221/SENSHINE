using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CustomerSegmentation
    {
        public int SegmentId { get; set; }
        public int? SpaId { get; set; }
        public string? SegmentName { get; set; }
        public string? Criteria { get; set; }
        public string? Benefits { get; set; }

        public virtual Spa? Spa { get; set; }
    }
}
