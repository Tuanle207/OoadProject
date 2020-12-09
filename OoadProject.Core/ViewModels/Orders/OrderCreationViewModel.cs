using OoadProject.Core.Services.AppProduct;
using OoadProject.Core.ViewModels.Orders.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OoadProject.Core.ViewModels.Orders
{
    public class OrderCreationViewModel : BaseViewModel
    {
        // private service fields
        private readonly ProductService _productService;

        // private data fields
        private ObservableCollection<Product> _products;
        private int _currentPage;
        private int _totalPages;
        private ObservableCollection<Product> _selectedProducts;
        private Product product;

        // public data properties
        public ObservableCollection<Product> Products
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

        private ObservableCollection<Product> SelectedProducts
        {
            get => _selectedProducts;
            set
            {
                _selectedProducts = value;
                OnPropertyChanged();
            }
        }
        public Product Product { get; set; }

        // public command properties

        public ICommand GoNextPage { get; set; }
        public ICommand GoPrevPage { get; set; }
        public ICommand AddItem { get; set; }
        public ICommand RemoveItem { get; set; }




        public OrderCreationViewModel()
        {
            _productService = new ProductService();

            var pagedList = _productService.GetProductsForOrderCreation();
            
            CurrentPage = pagedList.CurrentPage;
            TotalPages = pagedList.TotalPages;
            Products = new ObservableCollection<Product>(pagedList);

            SelectedProducts = new ObservableCollection<Product>();


            // Command
            GoNextPage = new RelayCommand<object>(
            p => CurrentPage < TotalPages,
            p => {
                CurrentPage = CurrentPage + 1;
                Products = new ObservableCollection<Product>(_productService.GetProductsForOrderCreation(CurrentPage));
                
            }) ;

            GoPrevPage = new RelayCommand<object>(
            p => CurrentPage > 1,
            p => {
                CurrentPage = CurrentPage - 1;
                Products = new ObservableCollection<Product>(_productService.GetProductsForOrderCreation(CurrentPage));
            });

            AddItem = new RelayCommand<object>(
            p => true,
            p => {
                SelectedProducts.Add()
            });

            RemoveItem = new RelayCommand<object>(
            p => true,
            p => {
                CurrentPage = CurrentPage - 1;
                Products = new ObservableCollection<Product>(_productService.GetProductsForOrderCreation(CurrentPage));
            });

        }
    }
}
