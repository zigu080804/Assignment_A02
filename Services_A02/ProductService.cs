using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;
using Repository_A02;

namespace Services_A02
{
    public class ProductService : IProductService
    {
        IProductRepository prorepo;
        public ProductService()
        {
            prorepo = new ProductRepository();
        }

        public void AddProduct(Product product)
        {
            prorepo.AddProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            prorepo.DeleteProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return prorepo.GetAllProducts();
        }

        public Product? GetProductById(int productId)
        {
            return prorepo.GetProductById(productId);
        }

        public List<Product> SearchProducts(string keyword)
        {
            return prorepo.SearchProducts(keyword);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            prorepo.UpdateProduct(updatedProduct);
        }
    }
}
