using System.ComponentModel;

namespace Web.Models
{
    public class ServiceViewModel
    {
        [DisplayName("Service ID")]
        public int Id { get; set; }

        [DisplayName("Service Name")]
        public string ServiceName { get; set; } = null!;

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}