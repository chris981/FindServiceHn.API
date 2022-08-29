using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CountriesManager
{
    public interface ICountriesManager
    {
        Task<IEnumerable<Countries>> GetAllAsync();
        Task<Countries> CreateCountryAsync(CountriesDTO countries);
        Task<bool> DeleteCountryAsync(int id);
        Task<Countries> UpdateCountryAsync(Countries countries);
        Countries GetById(int id);
    }
}
