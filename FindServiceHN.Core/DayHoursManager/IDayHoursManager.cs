using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.DayHoursManager
{
    public interface IDayHoursManager
    {
        Task<IEnumerable<DayHour>> GetAllAsync();
        Task<DayHour> CreateDayHoursAsync(DayHoursDTO dayhours);
        Task<bool> DeleteDayHoursAsync(int id);
        Task<DayHour> UpdateDayHoursAsync(DayHour dayhours);
        DayHour GetById(int id);
    }
}
