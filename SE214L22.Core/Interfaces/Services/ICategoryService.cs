using SE214L22.Core.ViewModels.Settings.Dtos;
using SE214L22.Data.Entity.AppProduct;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
{
    public interface ICategoryService : IBaseService
    {
        Category AddCategory(CategoryForCreationDto category);
        bool DeleteCategory(CategoryForDisplayDto category);
        IEnumerable<Category> GetCategories();
        IEnumerable<CategoryForDisplayDto> GetDisplayCategories();
        bool UpdateCategory(CategoryForDisplayDto category);
    }
}