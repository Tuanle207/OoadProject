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
                var users = ctx.Users
                    .FilterDeleted()
                    .Include(u => u.Role)
                    .ToList();
                return users;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Users
                    .FilterDeleted()
                    .Where(u => u.Email == email)
                    .Include(u => u.Role)
                    .FirstOrDefault();
            }
        }

        public void UpdateUserPassword(int userId, string hashedPassword)
        {
            using (var ctx = new AppDbContext())
            {
                var user = ctx.Users.Where(u => u.Id == userId).FirstOrDefault();
                if (user != null)
                {
                    user.Password = hashedPassword;
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("Người dùng này không tồn tại!");
            }
        }
    }

    static class Extension
    {
        public static IQueryable<User> FilterDeleted(this IQueryable<User> query)
        {
            return query.Where(u => u.IsDeleted != true);
        }
    }
}
