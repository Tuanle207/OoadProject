using System.Windows.Input;
using System.Collections.ObjectModel;
using SE214L22.Shared.Permissions;
using SE214L22.Contract.Util;
using SE214L22.Contract.Services;
using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;

namespace SE214L22.Core.ViewModels.Users
{
    public class SessionViewModel : BaseViewModel
    {
        private readonly ISession _session;

        // service
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        // data field
        private LoginDto _loginDto;
        private UserForPasswordUpdateDto _userForPasswordUpdate;
        private ObservableCollection<Permission> _userPerrmissions;

        // data property
        public LoginDto LoginDto { get => _loginDto; set { _loginDto = value; OnPropertyChanged(); } }

        public string UserName
        {
            get
            {
                if (!_session.IsLoggedIn())
                    return null;
                return _session.CurrentUser.Name;
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

        public ObservableCollection<Permission> UserPerrmissions
        {
            get => _userPerrmissions;
            set
            {
                _userPerrmissions = value;
                OnPropertyChanged();
            }
        }


        // command
        public ICommand Login { get; set; }
        public ICommand Logout { get; set; }
        public ICommand ReloadUsername { get; set; }
        public ICommand UpdatePassword { get; set; }

        public SessionViewModel(IUserService userService, IRoleService roleService, ISession session)
        {
            _session = session;
            _userService = userService;
            _roleService = roleService;

            LoginDto = new LoginDto { Email = "", Password = "" };
            UserForPasswordUpdate = new UserForPasswordUpdateDto();
            UserPerrmissions = new ObservableCollection<Permission>();


            Login = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    if (p != null && (bool)p == true)
                    {
                        var authenticatedUser = _userService.Login(LoginDto);

                        // setup session and permissions info
                        _session.SetSessionUser(authenticatedUser);
                        UserPerrmissions = new ObservableCollection<Permission>(_roleService.GetRolePermissions(authenticatedUser.RoleId));

                        // check if this is a master admin?
                        if (MasterAdmins.Emails.Contains(authenticatedUser.Email))
                            _session.SetIsMasterAdmin(true);
                        else
                            _session.SetIsMasterAdmin(false);

                        // reset input
                        LoginDto.Password = "";
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
                        _session.SetSessionUser(null);
                        UserPerrmissions = new ObservableCollection<Permission>();
                        _session.SetIsMasterAdmin(false);
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
                        UserForPasswordUpdate.Id = _session.CurrentUser.Id;
                        _userService.UpdateUserPassword(UserForPasswordUpdate);
                    }
                }
            );
        }
    }
}
