using SE214L22.Data.Entity.AppProduct;
using SE214L22.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE214L22.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
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
