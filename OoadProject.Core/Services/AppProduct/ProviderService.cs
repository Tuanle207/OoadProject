using OoadProject.Core.ViewModels.Providers.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services.AppProduct
{
    public class ProviderService : BaseService
    {
        private readonly ProviderRepository _providerRepository;

        public ProviderService()
        {
            _providerRepository = new ProviderRepository();
        }

        public IEnumerable<Provider> GetProviders()
        {
            return _providerRepository.GetProviders();
        }

        public Provider AddProvider(ProviderForCreationDto provider)
        {
            var newProvider = Mapper.Map<Provider>(provider);

            return _providerRepository.CreateProvider(newProvider);
        }

        public bool DeleteProvider(Provider provider)
        {
            return _providerRepository.DeleteProvider(provider.Id);
        }
    }
}
