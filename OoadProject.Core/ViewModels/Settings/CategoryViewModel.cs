using OoadProject.Core.Services.AppProduct;
using OoadProject.Core.ViewModels.Settings.Dtos;
using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OoadProject.Core.ViewModels.Settings
{
    public class CategoryViewModel : BaseViewModel
    {
        // private service fields
        private readonly CategoryService _categoryService;

        // private data fields
        private ObservableCollection<Category> _categories;
        private Category _chosenCategory;
        private CategoryForCreationDto _newCategory;


        // public data properties
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }
        public Category ChosenCategory
        {
            get => _chosenCategory;
            set
            {
                _chosenCategory = value;
                OnPropertyChanged();
            }
        }
        public CategoryForCreationDto NewCategory
        {
            get => _newCategory;
            set
            {
                _newCategory = value;
                OnPropertyChanged();
            }
        }


        // public command properties
        public ICommand DeleteCategory { get; set; }
        public ICommand AddCategory { get; set; }
        public ICommand PrepareAddCategory { get; set; }

        public CategoryViewModel()
        {
            _categoryService = new CategoryService();

            Categories = new ObservableCollection<Category>(_categoryService.GetCategories());
            NewCategory = new CategoryForCreationDto { };

            DeleteCategory = new RelayCommand<object>
            (
                p => ChosenCategory == null ? false : true,
                p =>
                {
                    _categoryService.DeleteCategory(ChosenCategory);
                    Categories = new ObservableCollection<Category>(_categoryService.GetCategories());
                    MessageBox.Show("Xóa loại mặt hàng thành công");
                }
            );

            PrepareAddCategory = new RelayCommand<object>
            (
                p => true,
                p =>
                {
                    NewCategory = new CategoryForCreationDto { };
                }
             );

            AddCategory = new RelayCommand<object>
            (
                p =>
                {
                    if (NewCategory.Name == null || NewCategory.Description == null || NewCategory.ReturnRate == null )
                        return false;
                    return true;
                }
                    ,
                p =>
                {
                    _categoryService.AddCategory(NewCategory);
                    Categories = new ObservableCollection<Category>(_categoryService.GetCategories());
                    MessageBox.Show("Thêm loại mặt hàng thành công");
                }
            );
        }
    }
}
