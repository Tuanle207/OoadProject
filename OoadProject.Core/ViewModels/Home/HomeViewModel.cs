using OoadProject.Core.Services;
using OoadProject.Core.Services.AppProduct;
using OoadProject.Core.ViewModels.Home.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        // private service fields
        private readonly OrderService _orderService;
        private readonly InvoiceService _invoiceService;

        // private data fields
        private ObservableCollection<ProcessingOrderDto> _processingOrders;
        private RevenueDto _todayRevenue;
        private RevenueDto _monthRevenue;

        // public properties
        public ObservableCollection<ProcessingOrderDto> ProcessingOrders
        {
            get => _processingOrders;
            set
            {
                _processingOrders = value;
                OnPropertyChanged();
            }
        }
        public RevenueDto TodayRevenue
        {
            get => _todayRevenue;
            set 
            {
                _todayRevenue = value;
                OnPropertyChanged();
            }
        }

        public RevenueDto MonthRevenue
        {
            get => _monthRevenue;
            set
            {
                _monthRevenue = value;
                OnPropertyChanged();
            }
        }

        // public command properties



        public HomeViewModel()
        {
            // init services
            _orderService = new OrderService();
            _invoiceService = new InvoiceService();

            // init data
            ProcessingOrders = new ObservableCollection<ProcessingOrderDto>(_orderService.GetProcessingOrders());
            TodayRevenue = _invoiceService.GetRevenue(DateTime.Now, TimeType.Day);
            MonthRevenue = _invoiceService.GetRevenue(DateTime.Now, TimeType.Month);

        }
    }
}
