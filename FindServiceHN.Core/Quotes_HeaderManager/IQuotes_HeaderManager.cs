using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FindServiceHN.Core.Quotes_HeaderManager
{
    public interface IQuotes_HeaderManager
    {
         Task<IEnumerable<Quotes_Header>> GetAllAsync();
    }
}