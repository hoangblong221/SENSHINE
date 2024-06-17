using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Salary
    {
        public int IdSalary { get; set; }
        public int IdEmployee { get; set; }
        public decimal? BaseSalary { get; set; }
        public int? OvertimeHours { get; set; }
        public decimal? TotalSalary { get; set; }
        public int? SalaryMonth { get; set; }
        public int? SalaryYear { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
    }
}
