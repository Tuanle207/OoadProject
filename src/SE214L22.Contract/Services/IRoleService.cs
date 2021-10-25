using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface IRoleService : IBaseService
    {
        Role AddRole(Role role);
        bool DeleteRole(int roleId);
        IEnumerable<Role> GetAllRoles();
        IEnumerable<string> GetAllRolesNames();
        IEnumerable<Permission> GetRolePermissions(int roleId);
    }
}