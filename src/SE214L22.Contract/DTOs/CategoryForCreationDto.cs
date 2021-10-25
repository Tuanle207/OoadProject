using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE214L22.Contract.DTOs
{
    public class CategoryForCreationDto : BaseDto
    {
        private string _name;
        private string _description;
        private string _returnRate;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public string ReturnRate { get => _returnRate; set { _returnRate = value; OnPropertyChanged(); } }
    }
}
