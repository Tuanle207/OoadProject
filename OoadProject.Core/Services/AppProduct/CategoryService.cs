using OoadProject.Core.ViewModels.Settings.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services.AppProduct
{
    public class CategoryService : BaseService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public Category AddCategory(CategoryForCreationDto category)
        {
            var newCategory = Mapper.Map<Category>(category);

            return _categoryRepository.Create(newCategory);
        }

        public bool DeleteCategory(Category category)
        {
            return _categoryRepository.Delete(category.Id);
        }
    }
}
