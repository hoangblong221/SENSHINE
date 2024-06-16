namespace API.Models
{
    public class UserRole
    {
        public int ID_User { get; set; }
        public User User { get; set; }
        public int ID_Role { get; set; }
        public Role Role { get; set; }
    }
}
