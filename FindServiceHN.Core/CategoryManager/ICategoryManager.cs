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
    }
}
