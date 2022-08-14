using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindServiceHN.Core.Quotes_HeaderManager
{
    public class Quotes_HeaderManager
    {
        private readonly IRepository<Quotes_Header> quotes_headerRepository;

        public CategoryManager(IRepository<Quotes_Header> quotes_headerRepository)
        {
            this.quotes_headerRepository = quotes_headerRepository;
        }

        public async Task<IEnumerable<Quotes_Header>> GetAllAsync()
        {
            return await this.quotes_headerRepository.All().ToListAsync();
        }
    }
}