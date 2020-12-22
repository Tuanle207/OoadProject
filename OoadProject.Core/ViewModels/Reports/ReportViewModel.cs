using OoadProject.Core.Services.AppProduct;
using OoadProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.ViewModels.Reports
{
    public class ReportViewModel : BaseViewModel
    {
        // service
        private readonly InvoiceService _invoiceService;

        // private fields
        private DateTime _selectedDate;
        private int _totalDayRevenue;
        private ObservableCollection<ProductReportByDayDto> _products;

        private DateTime _selectedMonth;
        private int _totalRevenue;
        private int _totalProfit;
        private ObservableCollection<ItemReportByMonthDto> _dayStatistics;

        // public property
        public DateTime SelectedDate 
        { 
            get => _selectedDate; 
            set 
            { 
                _selectedDate = value; 
                OnPropertyChanged();
                LoadReportByDay();
            } 
        }
        public int TotalDayRevenue
        {
            get => _totalDayRevenue;
            set
            {
                _totalDayRevenue = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ProductReportByDayDto> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedMonth
        { 
            get => _selectedMonth; 
            set 
            {
                _selectedMonth = value;
                LoadReportByMonth();
                OnPropertyChanged(); 
            } 
        }
        public int TotalRevenue { get => _totalRevenue; set { _totalRevenue = value; OnPropertyChanged(); } } 
        public int TotalProfit { get => _totalProfit; set { _totalProfit = value; OnPropertyChanged(); } }
        public ObservableCollection<ItemReportByMonthDto> DayStatistics
        {
            get => _dayStatistics;
            set
            {
                _dayStatistics = value;
                OnPropertyChanged();
            }
        }

        // command

        public ReportViewModel()
        {
            // service
            _invoiceService = new InvoiceService();

            // init data
            SelectedDate = DateTime.Now;
            SelectedMonth = DateTime.Now;
        }

        private void LoadReportByDay()
        {
            var reportByDay = _invoiceService.GetReportByDay(SelectedDate);
            Products = new ObservableCollection<ProductReportByDayDto>(reportByDay.Products);
            TotalDayRevenue = reportByDay.TotalRevenue;
        }

        private void LoadReportByMonth()
        {
            var reportByMonth = _invoiceService.GetReportByMonth(SelectedMonth);
            DayStatistics = new ObservableCollection<ItemReportByMonthDto>(reportByMonth.DayStatistics);
            TotalRevenue = reportByMonth.TotalRevenue;
            TotalProfit = reportByMonth.TotalProfit;
        }
    }
}
