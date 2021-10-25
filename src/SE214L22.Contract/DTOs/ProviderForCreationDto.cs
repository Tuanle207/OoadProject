using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE214L22.Contract.DTOs
{
    public class ProviderForCreationDto : BaseDto
    {
        private string _name;
        private string  _phoneNumber;
        private string _email;
        private string _address;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public string Address { get => _address; set { _address = value; OnPropertyChanged(); } }
    }
}
