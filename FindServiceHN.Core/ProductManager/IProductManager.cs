using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ProductManager
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> CreateProductAsync(ProductDTO product);
        Task<bool> DeleteProductAsync(int id);
        Task<Product> UpdateProductAsync(Product product);
        Product GetById(int id);
    }
}
