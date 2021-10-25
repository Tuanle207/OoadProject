using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
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