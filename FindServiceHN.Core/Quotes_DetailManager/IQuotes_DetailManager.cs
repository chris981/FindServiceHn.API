using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.Quotes_DetailManager
{
    public interface IQuotes_DetailManager
    {
        Task<IEnumerable<Quotes_Detail>> GetAllAsyn();
    }
}