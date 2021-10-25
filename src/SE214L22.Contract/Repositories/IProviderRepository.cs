using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IProviderRepository : IBaseRepository<Provider>
    {
        IEnumerable<Provider> GetProviders();
    }
}