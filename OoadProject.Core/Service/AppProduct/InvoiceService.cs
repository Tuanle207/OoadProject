using OoadProject.Core.ViewModels.Home.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Service.AppProduct
{
    public class InvoiceService
    {
        /// <summary>
        /// Get general infomation about renenue and sales statistics
        /// </summary>
        /// <param name="date">Datetime context</param>
        /// <param name="type">Date or Month or Year?</param>
        public RevenueDto GetRevenue(DateTime dateTime, TimeType type = TimeType.Day)
        {
            RevenueDto dto = new RevenueDto();
            if (type == TimeType.Month)
            {
                // Get revenue of the day

                // 1. Get all InvoiceProducts

                // 2. 
            }
            else
            {
                // Get revenue of the month
            }
            return dto;


        }

        /// <summary>
        /// Get list of hot products in a period of time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="type">Day or Month or Year?</param>
        /// <returns></returns>
        public IEnumerable<HotProductDto> getHotProducts(DateTime dateTime, TimeType type = TimeType.Month)
        {
            if (type == TimeType.Day)
            {

            }
            else
            {

            }
            return null;
        }
    }
}
