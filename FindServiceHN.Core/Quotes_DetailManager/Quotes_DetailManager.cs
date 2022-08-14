using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.Quotes_DetailManager
{
    public class Quotes_DetailManager : IQuotes_DetailManager
    {
        private readonly IRepository<Quotes_Detail> quotes_detailRepository;

        public Quotes_DetailManager(IRepository<QuotesDetail> quotes_detailRepository)
        {
            this.quotes_detailRepository = quotes_detailRepository;
        }

        public async Task<IEnumerable<Quotes_Detail>> GetAllAsync()
        {
            return await this.quotes_detailRepository.All().ToListAsync();
        }
    }
}
