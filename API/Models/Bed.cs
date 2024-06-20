using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Bed
    {
        public Bed()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string BedNumber { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
