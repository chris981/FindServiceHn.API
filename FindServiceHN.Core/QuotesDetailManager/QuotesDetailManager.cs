using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.QuotesDetailManager
{
    public class QuotesDetailManager : IQuotesDetailManager
    {
        private readonly IRepository<QuotesDetail> quotesdetailRepository;

        public QuotesDetailManager(IRepository<QuotesDetail> quotesdetailRepository)
        {
            this.quotesdetailRepository = quotesdetailRepository;
        }

        public async Task<IEnumerable<QuotesDetail>> GetAllAsync()
        {
            return await this.quotesdetailRepository.All().ToListAsync();
        }
    }
}
