using SE214L22.Core.Interfaces.Services;
using SE214L22.Core.ViewModels.Settings.Dtos;
using SE214L22.Data.Entity.AppProduct;
using SE214L22.Data.Interfaces.Repositories;
using SE214L22.Data.Repository;
using System.Collections.Generic;

namespace SE214L22.Core.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public IEnumerable<CategoryForDisplayDto> GetDisplayCategories()
        {
            var listCategory = _categoryRepository.GetCategories();
            var listCategoryForReturn = Mapper.Map<List<CategoryForDisplayDto>>(listCategory);
            return listCategoryForReturn;
        }

        public Category AddCategory(CategoryForCreationDto category)
        {
            var newCategory = Mapper.Map<Category>(category);

            return _categoryRepository.Create(newCategory);
        }

        public bool DeleteCategory(CategoryForDisplayDto category)
        {
            var deleteCategory = Mapper.Map<Category>(category);
            return _categoryRepository.Delete(deleteCategory.Id);
        }
        public bool UpdateCategory(CategoryForDisplayDto category)
        {
            var editCategory = Mapper.Map<Category>(category);
            return _categoryRepository.Update(editCategory);
        }
    }
}
