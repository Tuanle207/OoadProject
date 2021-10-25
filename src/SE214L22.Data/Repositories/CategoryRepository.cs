using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SE214L22.Data.Repositories
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
