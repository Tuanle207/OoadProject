using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.ViewModels.Sells.Dtos
{
    public class InvoiceForCreationDto : BaseDto
    {
        private string _customerName;
        private string _phoneNumber;
        private int _total;

        public string CustomerName { get => _customerName; set { _customerName = value; OnPropertyChanged(); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(); } }
        public int Total { get => _total; set { _total = value; OnPropertyChanged(); } }
    }
}
