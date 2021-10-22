using SE214L22.Core.ViewModels.Customers.Dtos;
using SE214L22.Core.ViewModels.Products.Dtos;
using SE214L22.Data.Entity.AppCustomer;
using SE214L22.Shared.Dtos;
using SE214L22.Shared.Pagination;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
{
    public interface ICustomerService : IBaseService
    {
        Customer AddCustomer(CustomerForCreationDto userForCreation);
        bool DeleteCustomer(Customer user);
        Customer GetCustomer(int id);
        Customer GetCustomerByPhone(string phone);
        IEnumerable<Customer> GetCustomers();
        PaginatedList<CustomerDisplayDto> GetCustomersForDisplayCustomer(int page = 1, int limit = 15, CustomerFilterDto Filter = null);
        bool HidenCustomer(CustomerDisplayDto customer);
        void UpdateCustomer(CustomerDisplayDto userForUpdate);
    }
}