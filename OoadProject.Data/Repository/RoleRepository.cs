using OoadProject.Data.Entity.AppUser;
using System.Collections.Generic;
using System.Linq;

namespace OoadProject.Data.Repository
{
    public class RoleRepository
    {
        public Role Create(Role role)
        {
            using (var ctx = new AppDbContext())
            {
                var roleCreate = ctx.Roles.Add(role);
                ctx.SaveChanges();
                return roleCreate;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            using (var ctx = new AppDbContext())
            {
                var roles = ctx.Roles.ToList();
                return roles;
            }
        }

        public IEnumerable<string> GetAllRolesName()
        {
            using (var ctx = new AppDbContext())
            {
                var roles = ctx.Roles.ToList();
                var rolesNames = roles.Select(r => r.Name);
                return rolesNames;
            }
        }

        public Role GetRoleByName(string name)
        {
            using (var ctx = new AppDbContext())
            {
                var role = ctx.Roles.Where(r => r.Name == name).FirstOrDefault();
                return role;
            }
        }
    }
}
