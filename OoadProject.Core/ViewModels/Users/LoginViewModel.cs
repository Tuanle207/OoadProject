using OoadProject.Core.Services.AppProduct;
using OoadProject.Core.Services.AppUser;
using OoadProject.Core.AppSession;
using OoadProject.Core.ViewModels.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OoadProject.Core.ViewModels.Users
{
    public class LoginViewModel : BaseViewModel
    {
        // service
        private readonly UserService _userService;

        // data field
        private LoginDto _loginDto;
        private UserForPasswordUpdateDto _userForPasswordUpdate;

        // data property
        public LoginDto LoginDto { get => _loginDto; set { _loginDto = value; OnPropertyChanged(); } }

        public string UserName
        {
            get
            {
                if (!Session.IsLoggedIn())
                    return null;
                return Session.CurrentUser.Name;
            }
        }

        public UserForPasswordUpdateDto UserForPasswordUpdate
        {
            get => _userForPasswordUpdate;
            set
            {
                _userForPasswordUpdate = value;
                OnPropertyChanged();
            }
        }


        // command
        public ICommand Login { get; set; }
        public ICommand Logout { get; set; }
        public ICommand ReloadUsername { get; set; }
        public ICommand UpdatePassword { get; set; }

        public LoginViewModel()
        {
            _userService = new UserService();

            LoginDto = new LoginDto { Email = "letgo237@gmail.com", Password = "1248" };
            UserForPasswordUpdate = new UserForPasswordUpdateDto();


            Login = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    if (p != null && (bool)p == true)
                    {
                        var authenticatedUser = _userService.Login(LoginDto);
                        Session.SetSessionUser(authenticatedUser);
                        LoginDto = new LoginDto();
                    }
                } 
            );

            Logout = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    if (p != null && (bool)p == true)
                    {
                        Session.SetSessionUser(null);
                    }
                }
            );

            ReloadUsername = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    var x = UserName;
                    OnPropertyChanged(nameof(UserName));
                }
            );

            UpdatePassword = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    if (p != null && (bool)p)
                    {
                        UserForPasswordUpdate.Id = CurrentUser.Id;
                        _userService.UpdateUserPassword(UserForPasswordUpdate);
                    }
                }
            );
        }
    }
}
