using API.Models;

namespace API.Dtos
{
    public class ServiceDTO
    {
        public int IdSer { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? Description { get; set; }

        //public virtual ICollection<Review> Reviews { get; set; }
        //public virtual ICollection<Appointment> Appointments { get; set; }
        //public virtual ICollection<Card> IdCards { get; set; }
        //public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
