using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer_A02
{
    public class CategoryDAO
    {
        private LucySalesDataContext context = new LucySalesDataContext();

        public List<Category> GetAllCategories() => context.Categories.ToList();

        public Category? GetCategoryById(int categoryId)
        {
            return context.Categories
                          .Include(c => c.Products)
                          .FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category updatedCategory)
        {
            var existing = context.Categories.FirstOrDefault(c => c.CategoryId == updatedCategory.CategoryId);
            if (existing != null)
            {
                existing.CategoryName = updatedCategory.CategoryName;
                existing.Description = updatedCategory.Description;
                existing.Picture = updatedCategory.Picture;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            var category = context.Categories
                                  .Include(c => c.Products)
                                  .FirstOrDefault(c => c.CategoryId == categoryId);

            if (category == null)
                throw new InvalidOperationException("Không tìm thấy danh mục.");

            if (category.Products.Any())
                throw new InvalidOperationException("Không thể xóa vì có sản phẩm liên quan.");

            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public List<Category> SearchCategories(string keyword)
        {
            return context.Categories
                          .Where(c => c.CategoryName.Contains(keyword) ||
                                      c.Description.Contains(keyword))
                          .ToList();
        }
    }
}
