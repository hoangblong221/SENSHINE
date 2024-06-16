using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual User CustomerNavigation { get; set; } = null!;
    }
}
