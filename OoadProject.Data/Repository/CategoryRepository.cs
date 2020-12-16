using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public IEnumerable<Category> GetCategories()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Categories.ToList();
            }
        }
    }
}
