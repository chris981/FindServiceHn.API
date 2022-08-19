using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.DepartmentsManager
{
    public class DepartmentsManager : IDepartmentsManager
    {
        private readonly IRepository<Departments> DepartmentsRepository;

        public DepartmentsManager(IRepository<Departments> DepartmentsRepository)
        {
            this.DepartmentsRepository = DepartmentsRepository;
        }
        public async Task<IEnumerable<Departments>> GetAllAsync()
        {
            return await this.DepartmentsRepository.All().ToListAsync();
        }
    }
}
