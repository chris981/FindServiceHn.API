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
    }
}
