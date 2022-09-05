using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.SubCategoriesManager
{
    public class SubCategoriesManager : ISubCategoriesManager
    {
        private readonly IRepository<SubCategory> SubCategoriesRepository;

        public SubCategoriesManager(IRepository<SubCategory> SubCategoriesRepository)
        {
            this.SubCategoriesRepository = SubCategoriesRepository;
        }
        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            return await this.SubCategoriesRepository.All().ToListAsync();
        }
        public SubCategory GetById(int id)
        {
            var subcategories = this.SubCategoriesRepository.Find(id);
            if (subcategories == null) throw new KeyNotFoundException("not found");
            return subcategories;
        }
        public async Task<bool> DeleteSubCategoriesAsync(int id)
        {
            try
            {
                var subcategories = this.GetById(id);
                this.SubCategoriesRepository.Delete(subcategories);
                await this.SubCategoriesRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<SubCategory> UpdateSubCategoriesAsync(SubCategory subcategories)
        {
            try
            {
                var SubCategoriesToEdit = this.GetById(subcategories.IdSubCategories);
                SubCategoriesToEdit.IdSubCategories = subcategories.IdSubCategories;
                SubCategoriesToEdit.IdCategory = subcategories.IdCategory;
                SubCategoriesToEdit.Description = subcategories.Description;
                SubCategoriesToEdit.CreationDate = subcategories.CreationDate;
                SubCategoriesToEdit.IdUserCreation = subcategories.IdUserCreation;
                SubCategoriesToEdit.Image = subcategories.Image;

                var result = this.SubCategoriesRepository.Update(SubCategoriesToEdit);
                await this.SubCategoriesRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<SubCategory> CreateSubCategoriesAsync(SubCategoriesDTO subcategories)
        {
            if (subcategories != null)
            {
                var newSubCategory = new SubCategory
                {
                    IdSubCategories = subcategories.IdSubCategories,
                    IdCategory = subcategories.IdCategory,
                    Description = subcategories.Description,
                    CreationDate = subcategories.CreationDate,
                    IdUserCreation = subcategories.IdUserCreation,
                    Image = subcategories.Image,
                };

                var result = this.SubCategoriesRepository.Create(newSubCategory);
                await this.SubCategoriesRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
