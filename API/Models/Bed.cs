using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Bed
    {
        public Bed()
        {
            IdRooms = new HashSet<Room>();
        }

        public int IdBed { get; set; }
        public string BedNumber { get; set; } = null!;

        public virtual ICollection<Room> IdRooms { get; set; }
    }
}
