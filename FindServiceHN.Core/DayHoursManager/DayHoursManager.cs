using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.DayHoursManager
{
    public class DayHoursManager : IDayHoursManager
    {
        private readonly IRepository<DayHour> DayHoursRepository;

        public DayHoursManager(IRepository<DayHour> DayHoursRepository)
        {
            this.DayHoursRepository = DayHoursRepository;
        }
        public async Task<IEnumerable<DayHour>> GetAllAsync()
        {
            return await this.DayHoursRepository.All().ToListAsync();
        }
        public DayHour GetById(int id)
        {
            var dayhours = this.DayHoursRepository.Find(id);
            if (dayhours == null) throw new KeyNotFoundException("not found");
            return dayhours;
        }
        public async Task<bool> DeleteDayHoursAsync(int id)
        {
            try
            {
                var dayhours = this.GetById(id);
                this.DayHoursRepository.Delete(dayhours);
                await this.DayHoursRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<DayHour> UpdateDayHoursAsync(DayHour dayhours)
        {
            try
            {
                var DayHoursToEdit = this.GetById(dayhours.IdHour);
                DayHoursToEdit.IdHour = dayhours.IdHour;
                DayHoursToEdit.Hour = dayhours.Hour;

                var result = this.DayHoursRepository.Update(DayHoursToEdit);
                await this.DayHoursRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<DayHour> CreateDayHoursAsync(DayHoursDTO dayhours)
        {
            if (dayhours != null)
            {
                var newDayHour = new DayHour
                {
                    IdHour = dayhours.IdHour,
                    Hour = dayhours.Hour,
                };

                var result = this.DayHoursRepository.Create(newDayHour);
                await this.DayHoursRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
