using SE214L22.Core.ViewModels.Settings.Dtos;
using SE214L22.Data.Entity.AppCustomer;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
{
    public interface ICustomerLevelService : IBaseService
    {
        CustomerLevel GetCustomerLevelByName(string name);
        IEnumerable<CustomerLevel> GetCustomerLevels();
        IEnumerable<CustomerLevelForDisplayDto> GetDisplayCustomerLevels();
        bool UpdateCustomerLevel(CustomerLevelForDisplayDto customerLevel);
    }
}