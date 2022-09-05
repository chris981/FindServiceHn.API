using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.SubCategoriesManager
{
    public interface ISubCategoriesManager
    {
        Task<IEnumerable<SubCategory>> GetAllAsync();
        Task<SubCategory> CreateSubCategoriesAsync(SubCategoriesDTO subcategories);
        Task<bool> DeleteSubCategoriesAsync(int id);
        Task<SubCategory> UpdateSubCategoriesAsync(SubCategory subcategories);
        SubCategory GetById(int id);
    }
}
