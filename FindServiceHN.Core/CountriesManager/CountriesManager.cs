using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CountriesManager
{
    public class CountriesManager : ICountriesManager
    {
        private readonly IRepository<Countries> CountriesRepository;

        public CountriesManager(IRepository<Countries> CountriesRepository)
        {
            this.CountriesRepository = CountriesRepository;
        }

        public async Task<IEnumerable<Countries>> GetAllAsync()
        {
            return await this.CountriesRepository.All().ToListAsync();
        }
    }
}
