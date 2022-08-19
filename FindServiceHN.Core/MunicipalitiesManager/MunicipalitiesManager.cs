using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.MunicipalitiesManager
{
    public class MunicipalitiesManager : IMunicipalitiesManager
    {
        private readonly IRepository<Municipalities> MunicipalitiesRepository;

        public MunicipalitiesManager(IRepository<Municipalities> MunicipalitiesRepository)
        {
            this.MunicipalitiesRepository = MunicipalitiesRepository;
        }
        public async Task<IEnumerable<Municipalities>> GetAllAsync()
        {
            return await this.MunicipalitiesRepository.All().ToListAsync();
        }
    }
}
