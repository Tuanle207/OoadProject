using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.ViewModels.Home.Dto
{
    public class ProcessingOrderDto
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatedUser { get; set; }
        public string ProviderName { get; set; }
        public string Status { get; set; }
    }
}
