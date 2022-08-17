using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindServiceHN.Core.QuotesHeaderManager
{
    public class QuotesHeaderManager
    {
        private readonly IRepository<QuotesHeader> quotesheaderRepository;

        public CategoryManager(IRepository<Quotes_Header> quotesheaderRepository)
        {
            this.quotesheaderRepository = quotesheaderRepository;
        }

        public async Task<IEnumerable<QuotesHeader>> GetAllAsync()
        {
            return await this.quotesheaderRepository.All().ToListAsync();
        }
    }
}