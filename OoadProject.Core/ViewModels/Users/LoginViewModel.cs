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

        // data property
        public LoginDto LoginDto { get => _loginDto; set { _loginDto = value; OnPropertyChanged(); } }


        // command
        public ICommand Login { get; set; }

        public LoginViewModel()
        {
            _userService = new UserService();

            LoginDto = new LoginDto();

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
        }
    }
}
