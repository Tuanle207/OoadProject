using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Contract.Services;
using System.Collections.Generic;

namespace SE214L22.Core.Services
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role AddRole(Role role)
        {
            return _roleRepository.Create(role);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.GetAll();
        }

        public IEnumerable<string> GetAllRolesNames()
        {
            return _roleRepository.GetAllRolesName();
        }

        public IEnumerable<Permission> GetRolePermissions(int roleId)
        {
            return _roleRepository.GetRolePermissions(roleId);
        }

        public bool DeleteRole(int roleId)
        {
            return _roleRepository.Delete(roleId);
        }
    }
}
