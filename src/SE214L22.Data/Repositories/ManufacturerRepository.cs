using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SE214L22.Data.Repositories
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public IEnumerable<Manufacturer> GetManufacturers()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Manufacturers.ToList();
            }
        }
    }
}
