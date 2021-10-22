using SE214L22.Data.Entity.AppProduct;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IManufacturerRepository : IBaseRepository<Manufacturer>
    {
        IEnumerable<Manufacturer> GetManufacturers();
    }
}