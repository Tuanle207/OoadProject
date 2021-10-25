using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Contract.Services;
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
