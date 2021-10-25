using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IEnumerable<Category> GetCategories();
    }
}