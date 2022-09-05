using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await this.productRepository.All().ToListAsync();
        }
        public Product GetById(int id)
        {
            var product = this.productRepository.Find(id);
            if (product == null) throw new KeyNotFoundException("Not Found");
            return product;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var product = this.GetById(id);
                this.productRepository.Delete(product);
                await this.productRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                var productToEdit = this.GetById(product.IdProduct);
                productToEdit.IdProduct = product.IdProduct;
                productToEdit.IdProvider = product.IdProvider;
                productToEdit.IdCategory = product.IdCategory;
                productToEdit.Name = product.Name;
                productToEdit.Currency = product.Currency;
                productToEdit.CurrencyName = product.CurrencyName;
                productToEdit.Description = product.Description;
                productToEdit.Price = product.Price;
                productToEdit.ShippingStatus = product.ShippingStatus;

                var result = this.productRepository.Update(productToEdit);
                await this.productRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<Product> CreateProductAsync(ProductDTO product)
        {
            if (product != null)
            {
                var newproduct = new Product
                {
                    IdProvider = product.IdProvider,
                    IdCategory = product.IdCategory,
                    Name = product.Name,
                    Description = product.Description,
                    Currency = product.Currency,
                    CurrencyName = product.CurrencyName,
                    Price = product.Price,
                    ShippingStatus = product.ShippingStatus,
                };

                var result = this.productRepository.Create(newproduct);
                await this.productRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
