using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.DepartmentsManager
{
    public interface IDepartmentsManager
    {
        Task<IEnumerable<Departments>> GetAllAsync();
    }
}
