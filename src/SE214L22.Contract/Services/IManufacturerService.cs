using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface IManufacturerService : IBaseService
    {
        Manufacturer AddManufacturer(ManufacturerForCreationDto manufacturer);
        bool DeleteManufacturer(Manufacturer manufacturer);
        IEnumerable<Manufacturer> GetManufacturers();
    }
}