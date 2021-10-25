using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface IUserService : IBaseService
    {
        User AddUser(UserForCreationDto userForCreation);
        bool DeleteUser(User user);
        bool EmailHasBeenTaken(string email);
        string GetNewPassword(int userId);
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        User Login(LoginDto loginDto);
        void UpdateUser(UserForCreationDto userForUpdate, User currentUser);
        void UpdateUserPassword(UserForPasswordUpdateDto userForPasswordUpdate);
    }
}