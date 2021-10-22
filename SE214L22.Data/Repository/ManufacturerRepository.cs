using SE214L22.Data.Entity.AppProduct;
using SE214L22.Data.Interfaces.Repositories;
using SE214L22.Data.Entity.AppCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE214L22.Data.Repository
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
