using SE214L22.Core.ViewModels.Users.Dtos;
using SE214L22.Data.Entity.AppUser;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
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