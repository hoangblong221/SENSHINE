namespace API.Models
{
    public class RolePermission
    {
        public int ID_Role { get; set; }
        public Role Role { get; set; }
        public int ID_Per { get; set; }
        public Permission Permission { get; set; }
    }
}
