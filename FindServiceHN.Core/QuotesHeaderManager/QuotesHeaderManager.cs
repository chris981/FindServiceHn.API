using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindServiceHN.Core.QuotesHeaderManager
{
    public class QuotesHeaderManager
    {
        private readonly IRepository<QuotesHeader> quotesheaderRepository;

        public QuotesHeaderManager(IRepository<QuotesHeader> quotesheaderRepository, IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            this.quotesheaderRepository = quotesheaderRepository;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<QuotesHeader>> GetAllAsync()
        {
            return await this.quotesheaderRepository.All().ToListAsync();
        }
        public QuotesHeader GetById(int IdQuoteHeader)
        {
            var quotesheader = this.quotesheaderRepository.Find(IdQuoteHeader);
            if (quotesheader == null) throw new KeyNotFoundException("not found");
            return quotesheader;
        }

        public async Task<bool> DeleteUQuotesHeaderAsync(int IdQuoteHeader)
        {
            try
            {
                var quotesheader = this.GetById(IdQuoteHeader);
                this.quotesheaderRepository.Delete(quotesheader);
                await this.quotesheaderRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<QuotesHeader> UpdateQuotesHeaderAsync(QuotesHeader quotesheader)
        {
            try
            {
                var quotesheaderToEdit = this.GetById(quotesheader.IdQuoteHeader);
                quotesheaderToEdit.IdQuoteDetail = quotesheader.IdQuoteDetail;
                quotesheaderToEdit.IdCustomer = quotesheader.IdCustomer;
                quotesheaderToEdit.IdProvider = quotesheader.IdProvider;
                quotesheaderToEdit.IdClientAddres = quotesheader.IdClientAddres;
                quotesheaderToEdit.Description = quotesheader.Description;
                quotesheaderToEdit.IdCate = quotesheader.IdCate;
                quotesheaderToEdit.IdSubcategory = quotesheader.IdSubcategory;
                quotesheaderToEdit.CreationDate = quotesheader.CreationDate;
                quotesheaderToEdit.AssigmentDate = quotesheader.AssigmentDate;
                quotesheaderToEdit.IStatus = quotesheader.IStatus;
                quotesheaderToEdit.CustomerObservation = quotesheader.CustomerObservation;
                quotesheaderToEdit.ProviderObservation = quotesheader.ProviderObservation;
                quotesheaderToEdit.IStatusCreationDate = quotesheader.IStatusCreationDate;

                var result = this.quotesheaderRepository.Update(quotesheaderToEdit);
                await this.quotesheaderRepository.SaveChangesAsync();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<QuotesHeader> CreateQuotesHeaderAsync(QuotesHeaderDTO quotesheader)
        {
            if (quotesheader != null)
            {
                var newQuotesHeader = new QuotesHeader
                {
                    IdQuoteDetail = quotesheader.IdQuoteDetail,
                    IdCustomer = quotesheader.IdCustomer,
                    IdProvider = quotesheader.IdProvider,
                    IdClientAddres = quotesheader.IdClientAddres,
                    Description = quotesheader.Description,
                    IdCate = quotesheader.IdCate,
                    IdSubcategory = quotesheader.IdSubcategory,
                    CreationDate = quotesheader.CreationDate,
                    AssigmentDate = quotesheader.AssigmentDate,
                    IStatus = quotesheader.IStatus,
                    CustomerObservation = quotesheader.CustomerObservation,
                    ProviderObservation = quotesheader.ProviderObservation,
                    IStatusCreationDate = quotesheader.IStatusCreationDate,                  
                };

                var result = this.quotesheaderRepository.Create(newQuotesHeader);
                await this.quotesheaderRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}