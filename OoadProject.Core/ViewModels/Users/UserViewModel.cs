using OoadProject.Core.Services.AppUser;
using OoadProject.Data.Entity.AppUser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.ViewModels.Users
{
    public class UserViewModel : BaseViewModel
    {
        // private service fields
        private readonly UserService _userService;

        // private data fields
        private ObservableCollection<User> _users;

        // public data properties
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        // public command properties

        public UserViewModel()
        {
            _userService = new UserService();

            Users = new ObservableCollection<User>(_userService.GetUsers());
        }
    }
}
