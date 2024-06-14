using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; } = null!;

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
