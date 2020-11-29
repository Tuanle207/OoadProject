using OoadProject.Core.ViewModels.Home.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Service.AppProduct
{
    public class OrderService
    {
        /// <summary>
        /// Get processing orders includes all except for completed order (status done)
        /// </summary>
        /// <param name="limit">Limit number or order loaded</param>
        public ProcessingOrderDto GetProcessingOrder(int limit)
        {
            return null;
        }

    }
}
