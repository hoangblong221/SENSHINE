namespace API.Models
{
    public class User
    {
        public int ID_User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
