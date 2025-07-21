using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using DataAccessLayer_A02;

namespace Repository_A02
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO prodao =  new ProductDAO();

        public void AddProduct(Product product)
        {
            prodao.AddProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            prodao.DeleteProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return prodao.GetAllProducts();
        }

        public Product? GetProductById(int productId)
        {
            return prodao.GetProductById(productId);
        }

        public List<Product> SearchProducts(string keyword)
        {
            return prodao.SearchProducts(keyword);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            prodao.UpdateProduct(updatedProduct);
        }
    }
}
