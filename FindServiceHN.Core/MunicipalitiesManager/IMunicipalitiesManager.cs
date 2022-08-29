using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.MunicipalitiesManager
{
    public interface IMunicipalitiesManager
    {
        Task<IEnumerable<Municipalities>> GetAllAsync();
        Task<Municipalities> CreateMunicipalityAsync(MunicipalitiesDTO municipalities);
        Task<bool> DeleteMunicipalityAsync(int id);
        Task<Municipalities> UpdateMunicipalityAsync(Municipalities municipalities);
        Municipalities GetyById(int id);
    }
}
