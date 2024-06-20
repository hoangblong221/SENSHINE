using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly SenShineSpaContext _context;

        public UserService(SenShineSpaContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.Include(r => r.Roles).SingleOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return user;
        }

        public async Task<User> AddUser(string username, string password)
        {
            var user = await _context.Users.Include(r => r.Roles).SingleOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
