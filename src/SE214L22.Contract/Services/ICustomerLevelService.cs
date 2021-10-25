using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface ICustomerLevelService : IBaseService
    {
        CustomerLevel GetCustomerLevelByName(string name);
        IEnumerable<CustomerLevel> GetCustomerLevels();
        IEnumerable<CustomerLevelForDisplayDto> GetDisplayCustomerLevels();
        bool UpdateCustomerLevel(CustomerLevelForDisplayDto customerLevel);
    }
}