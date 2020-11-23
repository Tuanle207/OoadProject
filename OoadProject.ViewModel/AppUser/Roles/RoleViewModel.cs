using OoadProject.Data.Entity.AppUser;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OoadProject.ViewModel.AppUser.Roles
{
    public class RoleViewModel : ViewModel
    {
        // private service fields
        private RoleService _roleService;

        // private data fields
        private ObservableCollection<Role> _roles;
        private Role _editingRole;

        // public data properties
        public ObservableCollection<Role> Roles 
        {
            get => _roles;
            set
            {
                _roles = value;
                OnPropertyChanged();
            } 
        }

        public Role EditingRole 
        {
            get => _editingRole; 
            set {
                _editingRole = value;
                OnPropertyChanged();
            }
        }

        // commands
        public ICommand AddRoleCommand { get; set; }

       

        public RoleViewModel()
        {
            // init services
            _roleService = new RoleService();

            // init commands
            AddRoleCommand = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    OnPropertyChanged(nameof(EditingRole));



                    var roleJustCreated = _roleService.AddRole(EditingRole);



                    Roles.Add(roleJustCreated);
                    EditingRole = new Role();
                    OnPropertyChanged(nameof(EditingRole));
                }
            );

            // init datas
            Roles = new ObservableCollection<Role>(_roleService.GetAllRoles());
            EditingRole = new Role();
        }

        
    }
}
