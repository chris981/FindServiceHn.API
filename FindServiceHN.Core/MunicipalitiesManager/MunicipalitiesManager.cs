using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.MunicipalitiesManager
{
    public class MunicipalitiesManager : IMunicipalitiesManager
    {
        private readonly IRepository<Municipalities> MunicipalitiesRepository;

        public MunicipalitiesManager(IRepository<Municipalities> MunicipalitiesRepository)
        {
            this.MunicipalitiesRepository = MunicipalitiesRepository;
        }
        public async Task<IEnumerable<Municipalities>> GetAllAsync()
        {
            return await this.MunicipalitiesRepository.All().ToListAsync();
        }
        public Municipalities GetById(int id)
        {
            var municipality = this.MunicipalitiesRepository.Find(id);
            if (municipality == null) throw new KeyNotFoundException("not found");
            return municipality;
        }
        public async Task<bool> DeleteMunicipalityAsync(int id)
        {
            try
            {
                var municipality = this.GetById(id);
                this.MunicipalitiesRepository.Delete(municipality);
                await this.MunicipalitiesRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<Municipalities> UpdateMunicipalityAsync(Municipalities municipalities)
        {
            try
            {
                var MunicipalityToEdit = this.GetById(municipalities.IdMunicipality);
                MunicipalityToEdit.IdMunicipality = municipalities.IdMunicipality;
                MunicipalityToEdit.IdDepartment = municipalities.IdDepartment;
                MunicipalityToEdit.IdCountry = municipalities.IdCountry;
                MunicipalityToEdit.Description = municipalities.Description;
                MunicipalityToEdit.CreationDate = municipalities.CreationDate;
                MunicipalityToEdit.IdUserCreation = MunicipalityToEdit.IdUserCreation;
                MunicipalityToEdit.IdStatus = municipalities.IdStatus;

                var result = this.MunicipalitiesRepository.Update(MunicipalityToEdit);
                await this.MunicipalitiesRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<Municipalities> CreateMunicipalityAsync(MunicipalitiesDTO municipalities)
        {
            if (municipalities != null)
            {
                var newMunicipality = new Municipalities
                {
                    IdDepartment = municipalities.IdDepartment,
                    IdCountry = municipalities.IdCountry,
                    Description = municipalities.Description,
                    CreationDate = municipalities.CreationDate,
                    IdUserCreation = municipalities.IdUserCreation,
                    IdStatus = municipalities.IdStatus,
                };

                var result = this.MunicipalitiesRepository.Create(newMunicipality);
                await this.MunicipalitiesRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
