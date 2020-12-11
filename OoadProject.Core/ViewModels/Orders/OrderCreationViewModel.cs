using OoadProject.Core.Services.AppProduct;
using OoadProject.Core.Services.AppUser;
using OoadProject.Core.ViewModels.Orders.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Entity.AppUser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace OoadProject.Core.ViewModels.Orders
{
    public class OrderCreationViewModel : BaseViewModel
    {
        // private service fields
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        private readonly UserService _userService;
        private readonly ProviderService _providerService;

        // private data fields
        private List<ProductForOrderCreationDto> _loadedProducts;
        private List<bool> _loaded;
        private int _pageSize;

        private ObservableCollection<ProductForOrderCreationDto> _products;
        private int _currentPage;
        private int _totalPages;
        private ObservableCollection<SelectingProductDto> _selectedProducts;
        private OrderForCreationDto _order;
        
        private ObservableCollection<User> _users;
        private User _selectingUser;
        private ObservableCollection<Provider> _providers;
        private Provider _selectingProvider;

        // public data properties
        public ObservableCollection<ProductForOrderCreationDto> Products
        { 
            get => _products; 
            set
            {
                _products = value;
                OnPropertyChanged();
            } 
        }

        public int CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged(); } }
        public int TotalPages { get => _totalPages; set { _totalPages = value; OnPropertyChanged(); } }

        public ObservableCollection<SelectingProductDto> SelectedProducts
        {
            get => _selectedProducts;
            set
            {
                _selectedProducts = value;
                OnPropertyChanged();
            }
        }

        public OrderForCreationDto Order { get => _order; set { _order = value; OnPropertyChanged(); }}

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }
        public User SelectingUser { get => _selectingUser; set { _selectingUser = value; OnPropertyChanged(); } }
        public ObservableCollection<Provider> Providers
        {
            get => _providers;
            set
            {
                _providers = value;
                OnPropertyChanged();
            }
        }
        public Provider SelectingProvider { get => _selectingProvider; set { _selectingProvider = value; OnPropertyChanged(); } }

        // public command properties

        public ICommand GoNextPage { get; set; }
        public ICommand GoPrevPage { get; set; }
        public ICommand AddItem { get; set; }
        public ICommand RemoveItem { get; set; }
        public ICommand SaveOrderInfo { get; set; }




        public OrderCreationViewModel()
        {
            // service
            _productService = new ProductService();
            _orderService = new OrderService();
            _userService = new UserService();
            _providerService = new ProviderService();


            // data
            var pagedList = _productService.GetProductsForOrderCreation();
            CurrentPage = pagedList.CurrentPage;
            TotalPages = pagedList.TotalPages;
            _pageSize = pagedList.PageRecords;
            Products = new ObservableCollection<ProductForOrderCreationDto>(pagedList.Data);
            
            _loadedProducts = new List<ProductForOrderCreationDto>();
            _loadedProducts.AddRange(pagedList.Data);
            _loaded = new List<bool>();
            for (int i = 0; i < TotalPages; i++) _loaded.Add(false);
            _loaded[0] = true;

            SelectedProducts = new ObservableCollection<SelectingProductDto>();

            Users = new ObservableCollection<User>(_userService.GetUsers());
            Providers = new ObservableCollection<Provider>(_providerService.GetProviders());
            SelectingUser = Users.Count > 0 ? Users[0] : null;
            SelectingProvider = Providers.Count > 0 ? Providers[0] : null;
            Order = new OrderForCreationDto { CreationTime = DateTime.Now };



            // Command
            GoNextPage = new RelayCommand<object>(
            p => CurrentPage < TotalPages,
            p => {

                CurrentPage = CurrentPage + 1;
                if (_loaded[CurrentPage - 1] == true)
                {
                    Products = new ObservableCollection<ProductForOrderCreationDto>();
                    var start = (CurrentPage - 1) * _pageSize;
                    var end = start + _pageSize;

                    for (var i = 0; i < _loadedProducts.Count; i++)
                        if (i >= start && i < end)
                            Products.Add(_loadedProducts[i]);
                }
                else
                {
                    var loadedProduct = _productService.GetProductsForOrderCreation(CurrentPage).Data;
                    Products = new ObservableCollection<ProductForOrderCreationDto>(loadedProduct);
                    _loadedProducts.AddRange(loadedProduct);
                    _loaded[CurrentPage - 1] = true;
                }
                
                
            }) ;

            GoPrevPage = new RelayCommand<object>(
            p => CurrentPage > 1,
            p => {
                CurrentPage = CurrentPage - 1;

                Products = new ObservableCollection<ProductForOrderCreationDto>();
                var start = (CurrentPage - 1) * _pageSize;
                var end = start + _pageSize;

                for (var i = 0; i < _loadedProducts.Count; i++)
                    if (i >= start && i < end)
                        Products.Add(_loadedProducts[i]);
            });

            AddItem = new RelayCommand<object>(
            p => {
                if (p != null)
                {
                    var type = p.GetType();
                    if (type == typeof(ProductForOrderCreationDto))
                        return ((ProductForOrderCreationDto)p).Number > 0;
                    else if (type == typeof(SelectingProductDto))
                    {
                        var actualProduct = _loadedProducts.Where(sp => sp.Id == ((SelectingProductDto)p).Id).FirstOrDefault();
                        return actualProduct.Number > 0;
                    }
                }
                return true;
            },
            p => {
                
                var type = p.GetType();

                if (p != null)
                {
                    // get product id
                    int productId = -1;
                    if (type == typeof(ProductForOrderCreationDto))
                        productId = ((ProductForOrderCreationDto)p).Id;
                    else if (type == typeof(SelectingProductDto))
                        productId = ((SelectingProductDto)p).Id;

                    // change no. product in 2 lists
                    var product = _loadedProducts.Where(sp => sp.Id == productId).FirstOrDefault();

                    var selectedProduct = SelectedProducts.Where(sp => sp.Id == productId).FirstOrDefault();
                    if (selectedProduct != null)
                        selectedProduct.SelectedNumber++;
                    else
                        SelectedProducts.Add(_orderService.SelectProduct(product));

                    //product.Number--;

                }
            });

            RemoveItem = new RelayCommand<object>(
            p => true,
            p => {
                var selectedProduct = (SelectingProductDto) p;
                selectedProduct.SelectedNumber--;
                if (selectedProduct.SelectedNumber == 0)
                    SelectedProducts.Remove(selectedProduct);

                //_loadedProducts.Where(sp => sp.Id == selectedProduct.Id).FirstOrDefault().Number++;
            });


            SaveOrderInfo = new RelayCommand<object>(
            p => 
            {
                if (SelectingUser == null || SelectingProvider == null || SelectedProducts.Count == 0)
                    return false;
                return true;
            },
            p =>
            {
                if (p != null && (bool)p)
                {
                    Order.ProviderId = SelectingProvider.Id;
                    Order.UserId = SelectingUser.Id;
                    _orderService.AddNewOrder(Order, SelectedProducts);
                }
               
            });
        }
    }
}
