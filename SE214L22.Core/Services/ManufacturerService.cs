using SE214L22.Core.Interfaces.Services;
using SE214L22.Core.ViewModels.Settings.Dtos;
using SE214L22.Data.Entity.AppProduct;
using SE214L22.Data.Interfaces.Repositories;
using SE214L22.Data.Repository;
using System.Collections.Generic;

namespace SE214L22.Core.Services
{
    public class ManufacturerService : BaseService, IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return _manufacturerRepository.GetManufacturers();
        }

        public Manufacturer AddManufacturer(ManufacturerForCreationDto manufacturer)
        {
            var newManufacturer = Mapper.Map<Manufacturer>(manufacturer);

            return _manufacturerRepository.Create(newManufacturer);
        }

        public bool DeleteManufacturer(Manufacturer manufacturer)
        {
            return _manufacturerRepository.Delete(manufacturer.Id);
        }
    }
}
