using OoadProject.Core.Services.AppProduct;
using OoadProject.Core.ViewModels.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OoadProject.Core.ViewModels.Products
{
    public class ProductViewModel : BaseViewModel
    {
        // private service fields
        private readonly ProductService _productService;

        // private data fields
        private List<ProductDisplayDto> _loadedProducts;
        private List<bool> _loadedPages;
        private ObservableCollection<ProductDisplayDto> _products;
        private int _currentPage;
        private int _totalPages;
        private int _pageSize;
        private string _productNameKeyword;

        // public data properties

        public ObservableCollection<ProductDisplayDto> Products
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

        public string ProductNameKeyword
        {
            get => _productNameKeyword;
            set
            {
                _productNameKeyword = value;
                OnPropertyChanged();
                ReloadProducts();
            }
        }

        // public command properties
        public ICommand GoNextPage { get; set; }
        public ICommand GoPrevPage { get; set; }

        public ProductViewModel()
        {
            // service
            _productService = new ProductService();

            // data
            var pagedList = _productService.GetProductsForDisplayProduct();
            Products = new ObservableCollection<ProductDisplayDto>(pagedList.Data);
            CurrentPage = pagedList.CurrentPage;
            TotalPages = pagedList.TotalPages;
            _pageSize = pagedList.PageRecords;

            _loadedProducts = new List<ProductDisplayDto>(pagedList.Data);
            _loadedPages = new List<bool>(TotalPages);
            for (int i = 0; i < TotalPages; i++)
                _loadedPages.Add(false);
            _loadedPages[0] = true;

            // command
            GoNextPage = new RelayCommand<object>
            (
                p => CurrentPage < TotalPages,
                p =>
                {
                    CurrentPage++;

                    if (_loadedPages[CurrentPage - 1] == true)
                    {
                        var start = (CurrentPage - 1) * _pageSize;
                        var end = start + _pageSize;
                        Products = new ObservableCollection<ProductDisplayDto>();
                        for (int i = start; i < _loadedProducts.Count; i++)
                            if (i < end)
                                Products.Add(_loadedProducts[i]);
                    }
                    else
                    {
                        var pagedListNextPage = _productService.GetProductsForDisplayProduct(CurrentPage);
                        Products = new ObservableCollection<ProductDisplayDto>(pagedListNextPage.Data);

                        _loadedProducts.AddRange(pagedListNextPage.Data);
                        _loadedPages[CurrentPage - 1] = true;
                    }
                }


            );

            GoPrevPage = new RelayCommand<object>
            (
                p => CurrentPage > 1,
                p =>
                {
                    CurrentPage--;
                    if (_loadedPages[CurrentPage - 1] == true)
                    {

                        var start = (CurrentPage - 1) * _pageSize;
                        var end = start + _pageSize;

                        Products = new ObservableCollection<ProductDisplayDto>();
                        for (int i = start; i < end; i++)
                            Products.Add(_loadedProducts[i]);
                    }
                    else
                    {
                        var pagedListPrevPage = _productService.GetProductsForDisplayProduct(CurrentPage);
                        Products = new ObservableCollection<ProductDisplayDto>(pagedListPrevPage.Data);
                        _loadedProducts.AddRange(pagedListPrevPage.Data);
                        _loadedPages[CurrentPage - 1] = true;
                    }

                }
            );

        }

        private void ReloadProducts()
        {
            // 
        }
    }

}