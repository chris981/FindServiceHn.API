using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CountriesManager
{
    public class CountriesManager : ICountriesManager
    {
        private readonly IRepository<Countries> CountriesRepository;

        public CountriesManager(IRepository<Countries> CountriesRepository)
        {
            this.CountriesRepository = CountriesRepository;
        }

        public async Task<IEnumerable<Countries>> GetAllAsync()
        {
            return await this.CountriesRepository.All().ToListAsync();
        }
        public Countries GetById(int id)
        {
            var countries = this.CountriesRepository.Find(id);
            if (countries == null) throw new KeyNotFoundException("Not Found");
            return countries;
        }
        public async Task<bool> DeleteCountryAsync(int id)
        {
            try
            {
                var country = this.GetById(id);
                this.CountriesRepository.Delete(country);
                await this.CountriesRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<Countries> UpdateCountryAsync(Countries countries)
        {
            try
            {
                var countryToEdit = this.GetById(countries.IdCountry);
                countryToEdit.IdCountry = countries.IdCountry;
                countryToEdit.Name = countries.Name;
                countryToEdit.CountryCode = countries.CountryCode;
                countryToEdit.IdStatus = countries.IdStatus;
                countryToEdit.IdUserCreation = countries.IdUserCreation;
                countryToEdit.CreationDate = countries.CreationDate;

                var result = this.CountriesRepository.Update(countryToEdit);
                await this.CountriesRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<Countries> CreateCountryAsync(CountriesDTO countries)
        {
            if (countries != null)
            {
                var newCountry = new Countries
                {
                   IdCountry = countries.IdCountry,
                   Name = countries.Name,
                   CountryCode = countries.CountryCode,
                   IdStatus = countries.IdStatus,
                   IdUserCreation = countries.IdUserCreation,
                   CreationDate = countries.CreationDate,
                };

                var result = this.CountriesRepository.Create(newCountry);
                await this.CountriesRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
