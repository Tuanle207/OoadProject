using SE214L22.Data.Entity.AppCustomer;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface ICustomerLevelRepository : IBaseRepository<CustomerLevel>
    {
        CustomerLevel GetCustomerLevelByName(string name);
        IEnumerable<CustomerLevel> GetCustomerLevels();
    }
}