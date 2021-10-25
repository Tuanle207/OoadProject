using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Contract.Services;
using System.Collections.Generic;

namespace SE214L22.Core.Services
{
    public class CustomerLevelService : BaseService, ICustomerLevelService
    {
        private readonly ICustomerLevelRepository _customerLevelRepository;

        public CustomerLevelService(ICustomerLevelRepository customerLevelRepository)
        {
            _customerLevelRepository = customerLevelRepository;
        }

        public IEnumerable<CustomerLevel> GetCustomerLevels()
        {
            return _customerLevelRepository.GetCustomerLevels();
        }

        public IEnumerable<CustomerLevelForDisplayDto> GetDisplayCustomerLevels()
        {
            var listCustomerLevel = _customerLevelRepository.GetCustomerLevels();
            var listCustomerLevelForReturn = Mapper.Map<List<CustomerLevelForDisplayDto>>(listCustomerLevel);
            return listCustomerLevelForReturn;
        }

        public bool UpdateCustomerLevel(CustomerLevelForDisplayDto customerLevel)
        {
            var editCustomerLevel = Mapper.Map<CustomerLevel>(customerLevel);
            return _customerLevelRepository.Update(editCustomerLevel);
        }

        public CustomerLevel GetCustomerLevelByName(string name)
        {
            return _customerLevelRepository.GetCustomerLevelByName(name);
        }
    }
}
