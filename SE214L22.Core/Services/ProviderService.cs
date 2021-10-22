using SE214L22.Core.Interfaces.Services;
using SE214L22.Core.ViewModels.Settings.Dtos;
using SE214L22.Data.Entity.AppProduct;
using SE214L22.Data.Interfaces.Repositories;
using SE214L22.Data.Repository;
using System.Collections.Generic;

namespace SE214L22.Core.Services
{
    public class ProviderService : BaseService, IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public IEnumerable<Provider> GetProviders()
        {
            return _providerRepository.GetProviders();
        }

        public Provider AddProvider(ProviderForCreationDto provider)
        {
            var newProvider = Mapper.Map<Provider>(provider);

            return _providerRepository.Create(newProvider);
        }

        public bool DeleteProvider(Provider provider)
        {
            return _providerRepository.Delete(provider.Id);
        }
    }
}
