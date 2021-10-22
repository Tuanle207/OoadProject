using SE214L22.Core.ViewModels.Settings.Dtos;
using SE214L22.Data.Entity.AppProduct;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
{
    public interface IManufacturerService : IBaseService
    {
        Manufacturer AddManufacturer(ManufacturerForCreationDto manufacturer);
        bool DeleteManufacturer(Manufacturer manufacturer);
        IEnumerable<Manufacturer> GetManufacturers();
    }
}