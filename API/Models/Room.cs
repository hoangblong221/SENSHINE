using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Room
    {
        public Room()
        {
            Beds = new HashSet<Bed>();
            Spas = new HashSet<Spa>();
        }

        public int Id { get; set; }
        public string RoomName { get; set; } = null!;

        public virtual ICollection<Bed> Beds { get; set; }
        public virtual ICollection<Spa> Spas { get; set; }
    }
}
