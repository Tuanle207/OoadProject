using OoadProject.Core.AppSession;
using OoadProject.Core.ViewModels.Home.Dtos;
using OoadProject.Core.ViewModels.Sells.Dtos;
using OoadProject.Data.Entity.AppCustomer;
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
        private readonly CustomerRepository _customerRepository;
        private readonly InvoiceProductRepository _invoiceProductRepository;

        public InvoiceService()
        {
            _invoiceRepository = new InvoiceRepository();
            _customerRepository = new CustomerRepository();
            _invoiceProductRepository = new InvoiceProductRepository();
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

                // 2. Get revenue
                dto.Revenue = _invoiceRepository.GetRevenueByDay(dateTime);
            }
            else  // Get revenue of the month
            {
                // 1. Get sales number
                dto.Sales = _invoiceRepository.GetSalesByMonth(dateTime);

                // 2. Get revenue
                dto.Revenue = _invoiceRepository.GetRevenueByMonth(dateTime);
            }

            return dto;
        }

        public void AddInvoice(InvoiceForCreationDto invoice, List<SelectingProductForSellDto> products)
        {
            // 1. add custom?
            var phoneNumber = invoice.PhoneNumber;

            // check if it's existing?
            var customer = _customerRepository.GetCustomByPhoneNumber(phoneNumber);
            var customerId = -1;

            if (customer == null)
            {
                customer = new Customer { Name = invoice.CustomerName, PhoneNumber = phoneNumber };
                var storedCustomer = _customerRepository.Create(customer);
                customerId = storedCustomer.Id;
            }
            else
            {
                customerId = customer.Id;
            }

            // 2. add invoice
            var storedInvoice = _invoiceRepository.Create(new Invoice
            {
                CustomerId = customerId,
                UserId = Session.CurrentUser.Id,
                CreationTime = DateTime.Now,
                Total = invoice.Total
            }); ;

            // 3. add invoice's products
            foreach (var product in products)
            {
                var invoiceProduct = new InvoiceProduct
                {
                    ProductId = product.Id,
                    Number = product.SelectedNumber,
                    InvoiceId = storedInvoice.Id
                };

                _invoiceProductRepository.Create(invoiceProduct);
            }
        }

    }
}
