using System.Collections.Generic;
using System.Linq;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;

namespace SE214L22.Data.Repositories
{
    public class CustomerLevelRepository : BaseRepository<CustomerLevel>, ICustomerLevelRepository
    {
        public IEnumerable<CustomerLevel> GetCustomerLevels()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.CustomerLevels.ToList();
            }
        }

        public CustomerLevel GetCustomerLevelByName(string name)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.CustomerLevels
                    .Where(u => u.Name == name)
                    .FirstOrDefault();
            }
        }
    }
}
