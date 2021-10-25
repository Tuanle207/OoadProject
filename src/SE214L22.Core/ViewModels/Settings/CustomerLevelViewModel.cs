using SE214L22.Contract.DTOs;
using SE214L22.Contract.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SE214L22.Core.ViewModels.Settings
{
    public class CustomerLevelViewModel : BaseViewModel
    {
        // private service fields
        private readonly ICustomerLevelService _customerLevelService;

        // private data fields
        private ObservableCollection<CustomerLevelForDisplayDto> _customerLevels;
        private CustomerLevelForDisplayDto _chosenCustomerLevel;


        // public data properties
        public ObservableCollection<CustomerLevelForDisplayDto> CustomerLevels
        {
            get => _customerLevels;
            set
            {
                _customerLevels = value;
                OnPropertyChanged();
            }
        }
        public CustomerLevelForDisplayDto ChosenCustomerLevel
        {
            get => _chosenCustomerLevel;
            set
            {
                _chosenCustomerLevel = value;
                OnPropertyChanged();
            }
        }


        // public command properties
        public ICommand UpdateCustomerLevel { get; set; }
        public ICommand PrepareUpdateCustomerLevel { get; set; }

        public CustomerLevelViewModel(ICustomerLevelService customerLevelService)
        {
            _customerLevelService = customerLevelService;

            CustomerLevels = new ObservableCollection<CustomerLevelForDisplayDto>(_customerLevelService.GetDisplayCustomerLevels());

            PrepareUpdateCustomerLevel = new RelayCommand<object>
            (
                p => ChosenCustomerLevel == null ? false : true,
                p =>
                {
                }
             );
            UpdateCustomerLevel = new RelayCommand<object>
            (
                p => ChosenCustomerLevel == null ? false : true,
                p =>
                {
                    if (p != null && (bool)p == true)
                    {
                        _customerLevelService.UpdateCustomerLevel(ChosenCustomerLevel);
                        CustomerLevels = new ObservableCollection<CustomerLevelForDisplayDto>(_customerLevelService.GetDisplayCustomerLevels());
                        MessageBox.Show("Cập nhật hạng khách hàng thành công!");
                    }
                }
             );
        }
    }
}
