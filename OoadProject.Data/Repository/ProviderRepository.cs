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

        public Provider CreateProvider(Provider provider)
        {
            using (var ctx = new AppDbContext())
            {
                var storedProvider = ctx.Providers.Add(provider);
                ctx.SaveChanges();
                return storedProvider;
            }
        }

        public bool DeleteProvider(int id)
        {
            using (var ctx = new AppDbContext())
            {
                var storedProvider = ctx.Providers.Where(p => p.Id == id).FirstOrDefault();
                ctx.Providers.Remove(storedProvider);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
