using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        int CountUsers();
        IEnumerable<User> GetAllUsers();
        User GetUserByEmail(string email);
        string GetUserPhotoById(int id);
        void UpdateUserPassword(int userId, string hashedPassword);
    }
}