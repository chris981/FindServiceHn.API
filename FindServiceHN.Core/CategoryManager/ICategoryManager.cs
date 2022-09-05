using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CategoryManager
{
    public interface ICategoryManager
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> CreateCategoryAsync(CategoryDTO category);
        Task<bool> DeleteCategoryAsync(int id);
        Task<Category> UpdateCategoryAsync(Category category);
        Category GetById(int id);
    }
}
