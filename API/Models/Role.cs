using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Role
    {
        public Role()
        {
            IdPers = new HashSet<Permission>();
            IdUsers = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Permission> IdPers { get; set; }
        public virtual ICollection<User> IdUsers { get; set; }
    }
}
