using OoadProject.Data.Entity.AppUser;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class UserRepository
    {
        public IEnumerable<User> GetAllUsers()
        {
            using (var ctx = new AppDbContext())
            {
                var users = ctx.Users.Include(u => u.Role).ToList();
                return users;
            }
        }

        public User CreateUser(User user)
        {
            using (var ctx = new AppDbContext())
            {
                var storedUser = ctx.Users.Add(user);
                ctx.SaveChanges();
                return storedUser;
            }
        }

        public bool UpdateUser(User user)
        {
            using (var ctx = new AppDbContext())
            {
                var storedUser = ctx.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                ctx.Entry(storedUser).CurrentValues.SetValues(user);
                ctx.SaveChanges();
                return true;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var ctx = new AppDbContext())
            {
                var storedUser = ctx.Users.Where(u => u.Id == id).FirstOrDefault();
                ctx.Users.Remove(storedUser);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
