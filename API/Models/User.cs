using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class User
    {
        public User()
        {
            Employees = new HashSet<Employee>();
            Notifications = new HashSet<Notification>();
            IdRoles = new HashSet<Role>();
        }

        public int IdUser { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<Role> IdRoles { get; set; }
    }
}
