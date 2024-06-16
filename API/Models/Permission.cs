namespace API.Models
{
    public class Permission
    {
        public int ID_Per { get; set; }
        public string PerName { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
