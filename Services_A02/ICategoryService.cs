using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;

namespace Services_A02
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryById(int categoryId);
        public void AddCategory(Category category);
        public void UpdateCategory(Category updatedCategory);
        public void DeleteCategory(int categoryId);
        public List<Category> SearchCategories(string keyword);
    }
}
