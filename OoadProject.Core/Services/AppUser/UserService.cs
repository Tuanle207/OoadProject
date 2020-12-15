﻿using OoadProject.Core.ViewModels.Users.Dtos;
using OoadProject.Data.Entity.AppUser;
using OoadProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services.AppUser
{
    public class UserService : BaseService
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User Login(LoginDto loginDto)
        {
            // get user with email
            var user = _userRepository.GetUserByEmail(loginDto.Email);

            // compare password?
            if (user.Password != loginDto.Password)
                throw new ArgumentException("Email hoặc mật khẩu không chính xác");

            // ok?
            return user;
        }

        public User AddUser(UserForCreationDto user)
        {
            var newUser = Mapper.Map<User>(user);

            var role = _roleRepository.GetRoleByName(user.Role);

            newUser.RoleId = role.Id;

            return _userRepository.Create(newUser);
        }

        public bool DeleteUser(User user)
        {
            return _userRepository.Delete(user.Id);
        }
    }
}
