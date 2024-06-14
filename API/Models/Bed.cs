using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Bed
    {
        public int BedId { get; set; }
        public int? RoomId { get; set; }
        public string? BedName { get; set; }
        public string? Status { get; set; }
        public DateTime? MaintenanceDate { get; set; }

        public virtual Room? Room { get; set; }
    }
}
