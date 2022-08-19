using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ProductManager
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<Product> productRepository;

        public ProductManager(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            if(product != null)
            {
                this.productRepository.Create(product);
                var result = await this.productRepository.SaveChangesAsync();
                return product;
            }
            return null;
        }
    }
}
