using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CategoryManager
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryManager(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await this.categoryRepository.All().ToListAsync();
        }
        public Category GetById(int id)
        {
            var category = this.categoryRepository.Find(id);
            if (category == null) throw new KeyNotFoundException("Not Found");
            return category;
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = this.GetById(id);
                this.categoryRepository.Delete(category);
                await this.categoryRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            try
            {
                var categoryToEdit = this.GetById(category.IdCategory);
                categoryToEdit.IdCategory = category.IdCategory;
                categoryToEdit.Description = category.Description;
                categoryToEdit.CreationDate = category.CreationDate;
                categoryToEdit.IdStatus = category.IdStatus;
                categoryToEdit.Image = category.Image;
                categoryToEdit.IdUserCreation = category.IdUserCreation;

                var result = this.categoryRepository.Update(categoryToEdit);
                await this.categoryRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<Category> CreateCategoryAsync(CategoryDTO category)
        {
            if (category != null)
            {
                var newcategory = new Category
                {
                    Description = category.Description,
                    CreationDate = category.CreationDate,
                    IdStatus = category.IdStatus,
                    Image = category.Image,
                    IdUserCreation = category.IdUserCreation,
                };

                var result = this.categoryRepository.Create(newcategory);
                await this.categoryRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
