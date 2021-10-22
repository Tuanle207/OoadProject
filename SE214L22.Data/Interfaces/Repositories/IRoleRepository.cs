using SE214L22.Data.Entity.AppUser;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Role Create(Role role);
        IEnumerable<Role> GetAll();
        IEnumerable<string> GetAllRolesName();
        Role GetRoleByName(string name);
        IEnumerable<Permission> GetRolePermissions(int roleId);
    }
}