using OoadProject.Data.Entity.AppUser;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public IEnumerable<User> GetAllUsers()
        {
            using (var ctx = new AppDbContext())
            {
                var users = ctx.Users.Include(u => u.Role).ToList();
                return users;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Users.Where(u => u.Email == email).FirstOrDefault();
            }
        }
    }
}
