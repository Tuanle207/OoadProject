using Microsoft.Extensions.DependencyInjection;
using SE214L22.Core.ViewModels.Customers;
using SE214L22.Core.ViewModels.Home;
using SE214L22.Core.ViewModels.Orders;
using SE214L22.Core.ViewModels.Products;
using SE214L22.Core.ViewModels.Reports;
using SE214L22.Core.ViewModels.Sells;
using SE214L22.Core.ViewModels.Settings;
using SE214L22.Core.ViewModels.Users;
using SE214L22.Core.ViewModels.Warranties;
using System;

namespace SE214L22
{
    internal class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator()
        {
            _serviceProvider = App.ServiceProvider;
        }

        public UserViewModel UserViewModel => _serviceProvider.GetRequiredService<UserViewModel>();
        public CustomerViewModel CustomerViewModel => _serviceProvider.GetRequiredService<CustomerViewModel>();
        public SessionViewModel SessionViewModel => _serviceProvider.GetRequiredService<SessionViewModel>();
        public HomeViewModel HomeViewModel => _serviceProvider.GetRequiredService<HomeViewModel>();
        public OrderCreationViewModel OrderCreationViewModel => _serviceProvider.GetRequiredService<OrderCreationViewModel>();
        public OrderViewModel OrderViewModel => _serviceProvider.GetRequiredService<OrderViewModel>();
        public ReceiptViewModel ReceiptViewModel => _serviceProvider.GetRequiredService<ReceiptViewModel>();
        public ReceiptCreationViewModel ReceiptCreationViewModel => _serviceProvider.GetRequiredService<ReceiptCreationViewModel>();
        public SellViewModel SellViewModel => _serviceProvider.GetRequiredService<SellViewModel>();
        public WarrantyOrderCreationViewModel WarrantyOrderCreationViewModel => _serviceProvider.GetRequiredService<WarrantyOrderCreationViewModel>();
        public WarrantyOrderListViewModel WarrantyOrderListViewModel => _serviceProvider.GetRequiredService<WarrantyOrderListViewModel>();
        public ProviderViewModel ProviderViewModel => _serviceProvider.GetRequiredService<ProviderViewModel>();
        public ManufacturerViewModel ManufacturerViewModel => _serviceProvider.GetRequiredService<ManufacturerViewModel>();
        public ParameterViewModel ParameterViewModel => _serviceProvider.GetRequiredService<ParameterViewModel>();
        public CategoryViewModel CategoryViewModel => _serviceProvider.GetRequiredService<CategoryViewModel>();
        public CustomerLevelViewModel CustomerLevelViewModel => _serviceProvider.GetRequiredService<CustomerLevelViewModel>();
        public ReportViewModel ReportViewModel => _serviceProvider.GetRequiredService<ReportViewModel>();
        public ProductViewModel ProductViewModel => _serviceProvider.GetRequiredService<ProductViewModel>();

    }
}
