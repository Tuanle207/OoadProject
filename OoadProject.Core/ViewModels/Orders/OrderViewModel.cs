using OoadProject.Core.Services.AppProduct;
using OoadProject.Core.ViewModels.Orders.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OoadProject.Core.ViewModels.Orders
{
    public class OrderViewModel : BaseViewModel
    {
        // service
        private readonly OrderService _orderService;

        // private field
        private ObservableCollection<OrderForListDto> _orders;
        private ObservableCollection<ProductForOrderListDto> _orderProducts;
        private OrderForListDto _selectedOrder;
        private bool _waitForSent;
        private bool _sent;
        private bool _done;
        private DateTime _dateFrom;
        private DateTime _dateTo;

        // public property
        public ObservableCollection<OrderForListDto> Orders { get => _orders; set { _orders = value; OnPropertyChanged(); } }
        public ObservableCollection<ProductForOrderListDto> OrderProducts { get => _orderProducts; set { _orderProducts = value; OnPropertyChanged(); } }
        public OrderForListDto SelectedOrder 
        { 
            get => _selectedOrder; 
            set 
            { 
                _selectedOrder = value;
                if (_selectedOrder != null) LoadOrderProducts();
                OnPropertyChanged(); 
            } 
        }
        public bool WaitForSent { get => _waitForSent; set { _waitForSent = value; OnPropertyChanged(); } }
        public bool Sent { get => _sent; set { _sent = value; OnPropertyChanged(); } }
        public bool Done { get => _done; set { _done = value; OnPropertyChanged(); } }
        public DateTime DateFrom { get => _dateFrom; set { _dateFrom = value; OnPropertyChanged(); } }
        public DateTime DateTo { get => _dateTo; set { _dateTo = value; OnPropertyChanged(); } }

        // public command
        public ICommand ToggleCheckOption { get; set; }
        public ICommand SearchWithFilter { get; set; }
        public ICommand ChangeStatusToWaitForSent { get; set; }
        public ICommand ChangeStatusToSent { get; set; }
        public ICommand ChangeStatusToDone { get; set; }

        public OrderViewModel()
        {

            // service
            _orderService = new OrderService();

            // data
            var filter = new List<OrderStatus>()
            {
                OrderStatus.WaitForSent,
                OrderStatus.Sent,
                OrderStatus.Done
            };
            Orders = new ObservableCollection<OrderForListDto>(_orderService.GetOrders(filter, null));
            SelectedOrder = null;
            OrderProducts = new ObservableCollection<ProductForOrderListDto>();

            WaitForSent = true;
            Sent = true;
            Done = true;

            DateFrom = DateTime.Now.AddMonths(-3);
            DateTo = DateTime.Now;


            // command
            ToggleCheckOption = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    if (p != null)
                    {
                        var checkOption = (OrderStatus)p;
                        switch (checkOption)
                        {
                            case OrderStatus.Sent:
                                Sent = !Sent;
                                break;
                            case OrderStatus.WaitForSent:
                                WaitForSent = !WaitForSent;
                                break;
                            case OrderStatus.Done:
                                Done = !Done;
                                break;
                            default:
                                break;
                        }
                    }
                }
            );

            SearchWithFilter = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    LoadOrdersWithFilter();
                }
            );

            ChangeStatusToWaitForSent = new RelayCommand<object>
            (
                p => SelectedOrder != null,
                p =>
                {
                    SelectedOrder.Status = (int)OrderStatus.WaitForSent;
                    _orderService.UpdateOrderStatus(SelectedOrder.Id, OrderStatus.WaitForSent);
                }
            );

            ChangeStatusToSent = new RelayCommand<object>
            (
                p => SelectedOrder != null,
                p =>
                {
                    SelectedOrder.Status = (int)OrderStatus.Sent;
                    _orderService.UpdateOrderStatus(SelectedOrder.Id, OrderStatus.Sent);
                }
            );

            ChangeStatusToDone = new RelayCommand<object>
            (
                p => SelectedOrder != null,
                p =>
                {
                    SelectedOrder.Status = (int)OrderStatus.Done;
                    _orderService.UpdateOrderStatus(SelectedOrder.Id, OrderStatus.Done);
                }
            );
        }

        private void LoadOrdersWithFilter()
        {
            // order status filter
            var filter = new List<OrderStatus>();
            if (WaitForSent) filter.Add(OrderStatus.WaitForSent);
            if (Sent) filter.Add(OrderStatus.Sent);
            if (Done) filter.Add(OrderStatus.Done);

            // datetime filter
            var dateRange = new DateRangeDto { StartDate = DateFrom, EndDate = DateTo };
            Orders = new ObservableCollection<OrderForListDto>(_orderService.GetOrders(filter, dateRange));
        }

        private void LoadOrderProducts()
        {
            OrderProducts = new ObservableCollection<ProductForOrderListDto>(_orderService.GetOrderProducts(SelectedOrder.Id));
        }
    }
}
