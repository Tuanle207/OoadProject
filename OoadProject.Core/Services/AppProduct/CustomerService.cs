using OoadProject.Data.Entity.AppCustomer;
using OoadProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services.AppProduct
{
    public class CustomerService : BaseService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public Customer GetCustomer(string phoneNumber)
        {
            return _customerRepository.GetCustomByPhoneNumber(phoneNumber);
        } 
    }
}
