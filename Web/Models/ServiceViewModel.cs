using System.ComponentModel;

namespace Web.Models
{
    public class ServiceViewModel
    {
        [DisplayName("Service ID")]
        public int IdSer { get; set; }

        [DisplayName("Service Name")]
        public string ServiceName { get; set; } = null!;

        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}
