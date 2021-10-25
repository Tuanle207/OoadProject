using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SE214L22.Data.Repositories
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
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
