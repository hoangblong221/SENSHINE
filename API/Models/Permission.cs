using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Permission
    {
        public Permission()
        {
            IdRoles = new HashSet<Role>();
        }

        public int IdPer { get; set; }
        public string PerName { get; set; } = null!;

        public virtual ICollection<Role> IdRoles { get; set; }
    }
}
