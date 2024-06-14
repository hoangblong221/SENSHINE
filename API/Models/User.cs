using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class User
    {
        public User()
        {
            AppointmentCustomers = new HashSet<Appointment>();
            AppointmentEmployees = new HashSet<Appointment>();
            Notifications = new HashSet<Notification>();
            Reviews = new HashSet<Review>();
            RewardPoints = new HashSet<RewardPoint>();
            Salaries = new HashSet<Salary>();
            Sales = new HashSet<Sale>();
            ServiceCards = new HashSet<ServiceCard>();
            Spas = new HashSet<Spa>();
            Transactions = new HashSet<Transaction>();
            UserRoles = new HashSet<UserRole>();
            WorkSchedules = new HashSet<WorkSchedule>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateRegistered { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<Appointment> AppointmentCustomers { get; set; }
        public virtual ICollection<Appointment> AppointmentEmployees { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<RewardPoint> RewardPoints { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<ServiceCard> ServiceCards { get; set; }
        public virtual ICollection<Spa> Spas { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
    }
}
