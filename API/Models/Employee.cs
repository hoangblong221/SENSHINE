using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int? SpaId { get; set; }
        public string FullName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }

        public virtual User EmployeeNavigation { get; set; } = null!;
        public virtual Spa? Spa { get; set; }
    }
}
