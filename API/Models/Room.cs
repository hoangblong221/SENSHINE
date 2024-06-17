using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Room
    {
        public Room()
        {
            IdBeds = new HashSet<Bed>();
            IdSpas = new HashSet<Spa>();
        }

        public int IdRoom { get; set; }
        public string RoomName { get; set; } = null!;

        public virtual ICollection<Bed> IdBeds { get; set; }
        public virtual ICollection<Spa> IdSpas { get; set; }
    }
}
