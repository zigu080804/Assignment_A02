using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer_A02
{
    public class ProductDAO
    {
        private LucySalesDataContext context = new LucySalesDataContext();

        public List<Product> GetAllProducts()
        {
            return context.Products
                          .Include(p => p.Category)
                          .ToList();
        }

        public Product? GetProductById(int productId)
        {
            return context.Products
                          .Include(p => p.Category)
                          .FirstOrDefault(p => p.ProductId == productId);
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var existing = context.Products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
            if (existing != null)
            {
                existing.ProductName = updatedProduct.ProductName;
                existing.CategoryId = updatedProduct.CategoryId;
                existing.SupplierId = updatedProduct.SupplierId;
                existing.QuantityPerUnit = updatedProduct.QuantityPerUnit;
                existing.UnitPrice = updatedProduct.UnitPrice;
                existing.UnitsInStock = updatedProduct.UnitsInStock;
                existing.UnitsOnOrder = updatedProduct.UnitsOnOrder;
                existing.ReorderLevel = updatedProduct.ReorderLevel;
                existing.Discontinued = updatedProduct.Discontinued;

                context.SaveChanges();
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = context.Products
                                 .Include(p => p.OrderDetails)
                                 .FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
                throw new InvalidOperationException("Không tìm thấy sản phẩm.");

            if (product.OrderDetails.Any())
                throw new InvalidOperationException("Không thể xóa vì sản phẩm đã từng được đặt hàng.");

            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> SearchProducts(string keyword)
        {
            return context.Products
                          .Include(p => p.Category)
                          .Where(p => p.ProductName.Contains(keyword))
                          .ToList();
        }
    }
}
