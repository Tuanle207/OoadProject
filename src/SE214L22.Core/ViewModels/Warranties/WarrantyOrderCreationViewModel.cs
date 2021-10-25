using SE214L22.Contract.DTOs;
using SE214L22.Contract.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SE214L22.Core.ViewModels.Warranties
{
    public class WarrantyOrderCreationViewModel : BaseViewModel
    {
        // private service
        private readonly IWarrantyService _warrantyService;

        // private data field
        private ObservableCollection<ProductForWarrantyDto> _customerProducts;
        private ProductForWarrantyDto _selectedProduct;
        private string _phoneNumber;

        // public data property
        public ObservableCollection<ProductForWarrantyDto> CustomerProducts
        {
            get => _customerProducts;
            set
            {
                _customerProducts = value;
                OnPropertyChanged();
            }
        }

        public ProductForWarrantyDto SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(); } }

        // public command property
        public ICommand GetCustomerProducts { get; set; }
        public ICommand AddWarrantyOrder { get; set; }


        public WarrantyOrderCreationViewModel(IWarrantyService warrantyService)
        {
            // service
            _warrantyService = warrantyService;

            // data
            CustomerProducts = new ObservableCollection<ProductForWarrantyDto>();
            SelectedProduct = null;

            // command
            GetCustomerProducts = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    CustomerProducts = new ObservableCollection<ProductForWarrantyDto>(_warrantyService.GetCustomerProductsForWarranty(PhoneNumber));
                    SelectedProduct = null;
                    OnPropertyChanged(nameof(CustomerProducts));
                }
            );

            AddWarrantyOrder = new RelayCommand<object>
            (
                p => SelectedProduct != null,
                p =>
                {
                    if (p != null && (bool)p == true) _warrantyService.AddNewWarrantyOrder(SelectedProduct);
                }
            );
        }
    }
}
