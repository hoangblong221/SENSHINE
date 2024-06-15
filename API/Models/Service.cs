using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Service
    {
        public Service()
        {
            Appointments = new HashSet<Appointment>();
            Reviews = new HashSet<Review>();
            ServiceCards = new HashSet<ServiceCard>();
        }

        public int ServiceId { get; set; }
        public int? SpaId { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Duration { get; set; }

        public virtual Spa? Spa { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ServiceCard> ServiceCards { get; set; }
    }
}
