using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using DataAccessLayer_A02;

namespace Repository_A02
{
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDAO catdao = new CategoryDAO();

        public void AddCategory(Category category)
        {
            catdao.AddCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            catdao.DeleteCategory(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return catdao.GetAllCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return catdao.GetCategoryById(categoryId);
        }

        public List<Category> SearchCategories(string keyword)
        {
            return catdao.SearchCategories(keyword);
        }

        public void UpdateCategory(Category updatedCategory)
        {
            catdao.UpdateCategory(updatedCategory);
        }
    }
}
