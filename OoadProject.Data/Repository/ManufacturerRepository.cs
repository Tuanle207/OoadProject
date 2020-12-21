using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>
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
