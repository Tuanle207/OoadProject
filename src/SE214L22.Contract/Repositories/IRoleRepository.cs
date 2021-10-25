using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        IEnumerable<Role> GetAll();
        IEnumerable<string> GetAllRolesName();
        Role GetRoleByName(string name);
        IEnumerable<Permission> GetRolePermissions(int roleId);
    }
}