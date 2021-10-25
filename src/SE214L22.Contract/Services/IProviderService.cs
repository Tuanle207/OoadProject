using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface IProviderService : IBaseService
    {
        Provider AddProvider(ProviderForCreationDto provider);
        bool DeleteProvider(Provider provider);
        IEnumerable<Provider> GetProviders();
    }
}