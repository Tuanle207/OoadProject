using SE214L22.Core.ViewModels.Settings.Dtos;
using SE214L22.Data.Entity.AppProduct;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
{
    public interface IProviderService : IBaseService
    {
        Provider AddProvider(ProviderForCreationDto provider);
        bool DeleteProvider(Provider provider);
        IEnumerable<Provider> GetProviders();
    }
}