using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using Repository_A02;

namespace Services_A02
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository icategoryRepository;
        public CategoryService()
        {
            icategoryRepository = new CategoryRepository();
        }
        public void AddCategory(Category category)
        {
            icategoryRepository.AddCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            icategoryRepository.DeleteCategory(categoryId);
        }

        public List<Category> GetAllCategories()
        {
              return  icategoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return icategoryRepository.GetCategoryById(categoryId);
        }

        public List<Category> SearchCategories(string keyword)
        {
            return icategoryRepository.SearchCategories(keyword);
        }

        public void UpdateCategory(Category updatedCategory)
        {
            icategoryRepository.UpdateCategory(updatedCategory);
        }
    }
}
