using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FindServiceHN.Core.Quotes_HeaderManager
{
    public interface IQuotesHeaderManager
    {
        Task<IEnumerable<QuotesHeader>> GetAllAsync();
        Task<QuotesHeader> CreateQuotesHeaderAsync(QuotesHeaderDTO quotesheader);
        Task<bool> DeleteQuotesHeaderAsync(int id);
        Task<QuotesHeader> UpdateQuotesHeaderAsync(QuotesHeader quotesheader);
        QuotesHeader GetById(int id)
    }
}