using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.ViewModels.Orders.Dtos
{
    public class ProductForOrderCreationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
    }
}
