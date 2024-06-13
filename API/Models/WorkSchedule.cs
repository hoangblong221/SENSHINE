using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class WorkSchedule
    {
        public int WorkScheduleId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? DayOfWeek { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public virtual User? Employee { get; set; }
    }
}
