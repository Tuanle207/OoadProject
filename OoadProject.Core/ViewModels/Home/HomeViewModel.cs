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
        private readonly OrderService _orderService;
        private ObservableCollection<ProcessingOrderDto> _processingOrders;

        public ObservableCollection<ProcessingOrderDto> ProcessingOrders
        {
            get => _processingOrders;
            set
            {
                _processingOrders = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            _orderService = new OrderService();
            ProcessingOrders = new ObservableCollection<ProcessingOrderDto>(_orderService.GetProcessingOrders());
        }
    }
}
