﻿using OoadProject.Data.Entity.AppUser;
using OoadProject.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OoadProject.ViewModel.AppUser.Roles
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService()
        {
            _roleRepository = new RoleRepository();
        }

        public Role AddRole(Role role)
        {
            return _roleRepository.Create(role);
        }
        public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.GetAll();
        }
    }
}