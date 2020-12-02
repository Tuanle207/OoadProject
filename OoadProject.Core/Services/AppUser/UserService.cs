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

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
