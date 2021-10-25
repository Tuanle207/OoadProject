using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface ICustomerLevelRepository : IBaseRepository<CustomerLevel>
    {
        CustomerLevel GetCustomerLevelByName(string name);
        IEnumerable<CustomerLevel> GetCustomerLevels();
    }
}