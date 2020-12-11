using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class ProviderRepository
    {
        public IEnumerable<Provider> GetProviders()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Providers.ToList();
            }
        }
    }
}
