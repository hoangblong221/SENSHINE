using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Appointments = new HashSet<Appointment>();
            Salaries = new HashSet<Salary>();
            WorkSchedules = new HashSet<WorkSchedule>();
        }

        public int IdEmployee { get; set; }
        public int IdUser { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}
