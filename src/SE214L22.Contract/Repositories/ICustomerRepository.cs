using SE214L22.Contract.Entities;
using SE214L22.Shared.Dtos;
using SE214L22.Shared.Pagination;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomByPhoneNumber(string phoneNumber);
        PaginatedList<Customer> GetCustomers(int page = 1, int limit = 15, CustomerFilterDto Filter = null);
    }
}