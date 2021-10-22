using SE214L22.Core.Interfaces.Services;
using SE214L22.Core.ViewModels.Customers.Dtos;
using SE214L22.Core.ViewModels.Products.Dtos;
using SE214L22.Data.Entity.AppCustomer;
using SE214L22.Data.Interfaces.Repositories;
using SE214L22.Data.Repository;
using SE214L22.Shared.Dtos;
using SE214L22.Shared.Pagination;
using System.Collections.Generic;

namespace SE214L22.Core.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public PaginatedList<CustomerDisplayDto> GetCustomersForDisplayCustomer(int page = 1, int limit = 15, CustomerFilterDto Filter = null)
        {
            var rawCustomers = _customerRepository.GetCustomers(page, limit, Filter);

            var customersForReturn = new PaginatedList<CustomerDisplayDto>
            (
                Mapper.Map<List<CustomerDisplayDto>>(rawCustomers.Data),
                rawCustomers.TotalRecords,
                rawCustomers.CurrentPage,
                rawCustomers.PageRecords
            );
            return customersForReturn;
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.Get(id);
        }

        public Customer GetCustomerByPhone(string phone)
        {
            return _customerRepository.GetCustomByPhoneNumber(phone);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }


        public Customer AddCustomer(CustomerForCreationDto userForCreation)
        {
            var newCustomer = Mapper.Map<Customer>(userForCreation);

            return _customerRepository.Create(newCustomer);
        }

        public void UpdateCustomer(CustomerDisplayDto userForUpdate)
        {

            var user = Mapper.Map<Customer>(userForUpdate);
            user.Id = (int)userForUpdate.Id;

            _customerRepository.Update(user);
        }
        public bool HidenCustomer(CustomerDisplayDto customer)
        {
            var hidenCustomer = Mapper.Map<Customer>(customer);
            hidenCustomer.IsDeleted = true;
            return _customerRepository.Update(hidenCustomer);
        }
        public bool DeleteCustomer(Customer user)
        {
            return _customerRepository.Delete(user.Id);
        }

    }
}
