using OoadProject.Core.Services.AppUser;
using OoadProject.Core.ViewModels.Users.Dtos;
using OoadProject.Data.Entity.AppUser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OoadProject.Core.ViewModels.Users
{
    public class UserViewModel : BaseViewModel
    {
        // private service fields
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        // private data fields
        private ObservableCollection<User> _users;
        private UserForCreationDto _editingUser;
        private ObservableCollection<string> _roles;
        private User _chosenUser;


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
        public UserForCreationDto EditingUser
        {
            get => _editingUser;
            set
            {
                _editingUser = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> Roles { 
            get => _roles;
            set
            {
                _roles = value;
                OnPropertyChanged();
            }
        }
        public User ChosenUser
        {
            get => _chosenUser;
            set
            {
                _chosenUser = value;
                OnPropertyChanged();
            }
        }


        // public command properties
        public ICommand SaveEditingUser { get; set; }
        public ICommand DeleteUser { get; set; }
        public ICommand ReloadUsers { get; set; }
        public ICommand GrantNewPassword { get; set; }

        public UserViewModel()
        {
            _userService = new UserService();
            _roleService = new RoleService();

            Users = new ObservableCollection<User>(_userService.GetUsers());
            EditingUser = new UserForCreationDto { CreationTime = DateTime.Now, Dob = new DateTime(2000, 1, 1) };
            Roles = new ObservableCollection<string>(_roleService.GetAllRolesNames());

            SaveEditingUser = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    if (p != null && (bool)p == true)
                        _userService.AddUser(EditingUser);
                }
            );

            DeleteUser = new RelayCommand<object>
            (
                p => ChosenUser == null ? false : true,
                p =>
                {
                    if (p != null && (bool)p == true)
                    {
                        _userService.DeleteUser(ChosenUser);
                        Users = new ObservableCollection<User>(_userService.GetUsers());
                    }
                       
                }
            );

            ReloadUsers = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    Users = new ObservableCollection<User>(_userService.GetUsers());
                }
            );

            GrantNewPassword = new RelayCommand<object>
            (
                p => ChosenUser != null,
                p =>
                {
                    if (p != null && (bool)p == true)
                    {
                        var newUserPassword = _userService.GetNewPassword(ChosenUser.Id);
                        MessageBox.Show($"Mật khẩu mới của nhân viên {ChosenUser.Name} là {newUserPassword} !");
                    }
                }
            );
        }
    }
}
