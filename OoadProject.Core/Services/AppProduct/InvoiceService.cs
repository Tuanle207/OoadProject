using OoadProject.Core.ViewModels.Home.Dtos;
using OoadProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services.AppProduct
{
    public class InvoiceService
    {
        private readonly InvoiceRepository _invoiceRepository;

        public InvoiceService()
        {
            _invoiceRepository = new InvoiceRepository();
        }

        /// <summary>
        /// Get general infomation about renenue and sales statistics
        /// </summary>
        /// <param name="date">Datetime context</param>
        /// <param name="type">Date or Month or Year?</param>
        public RevenueDto GetRevenue(DateTime dateTime, TimeType type = TimeType.Day)
        {
            RevenueDto dto = new RevenueDto();
            if (type == TimeType.Day)
            { // Get revenue of the day

                // 1. Get sales number
                dto.Sales = _invoiceRepository.GetSalesByDay(dateTime);

                // 2. Get all Invoices
                dto.Revenue = _invoiceRepository.GetRevenueByDay(dateTime);
            }
            else  // Get revenue of the month
            {
                // 1. Get sales number
                dto.Sales = _invoiceRepository.GetSalesByMonth(dateTime);

                // 2. Get all Invoices
                dto.Revenue = _invoiceRepository.GetRevenueByMonth(dateTime);
            }

            return dto;
        }

    }
}
