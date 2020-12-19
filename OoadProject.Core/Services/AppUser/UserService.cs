using OoadProject.Core.AppSession;
using OoadProject.Core.ViewModels.Users.Dtos;
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

        public User GetUser(int id)
        {
            return _userRepository.Get(id);
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
            if (user == null || !Session.ComparePassword(loginDto.Password, user.Password))
                throw new ArgumentException("Email hoặc mật khẩu không chính xác");

            // ok?
            return user;
        }

        public User AddUser(UserForCreationDto userForCreation)
        {
            var newUser = Mapper.Map<User>(userForCreation);

            var role = _roleRepository.GetRoleByName(userForCreation.Role);
            newUser.RoleId = role.Id;

            return _userRepository.Create(newUser);
        }

        public void UpdateUser(UserForCreationDto userForUpdate)
        {

            var role = _roleRepository.GetRoleByName(userForUpdate.Role);

            var user = Mapper.Map<User>(userForUpdate);
            user.Id = (int)userForUpdate.Id;
            user.RoleId = role.Id;

            _userRepository.Update(user);
        }

        public bool DeleteUser(User user)
        {
            return _userRepository.Delete(user.Id);
        }

        public bool EmailHasBeenTaken(string email)
        {
            return _userRepository.GetUserByEmail(email) != null;
        }

        public string GetNewPassword(int userId)
        {
            // 1. Generate new password
            var newPassword = Session.GetNewPassword();

            // 2. Hash new password just generated
            var hashedPassword = Session.HashPassword(newPassword);

            // 3. save new user's password in to DB
            _userRepository.UpdateUserPassword(userId, hashedPassword);

            return newPassword;

        }

        public void UpdateUserPassword(UserForPasswordUpdateDto userForPasswordUpdate)
        {
            var hashedPassword = Session.HashPassword(userForPasswordUpdate.Password);
            _userRepository.UpdateUserPassword(userForPasswordUpdate.Id, hashedPassword);
        }
    }
}
