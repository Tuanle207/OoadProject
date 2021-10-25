using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Contract.Services;
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
