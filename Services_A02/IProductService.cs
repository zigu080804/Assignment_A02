using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_A02;

namespace Services_A02
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();

        public Product? GetProductById(int productId);
        public void AddProduct(Product product);

        public void UpdateProduct(Product updatedProduct);
        public void DeleteProduct(int productId);
        public List<Product> SearchProducts(string keyword);
    }
}
