using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.QuotesDetailManager
{
    public class QuotesDetailManager : IQuotesDetailManager
    {
        private readonly IRepository<QuotesDetail> quotesdetailRepository;

        public QuotesDetailManager(IRepository<QuotesDetail> quotesdetailRepository, IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            this.quotesdetailRepository = quotesdetailRepository;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<QuotesDetail>> GetAllAsync()
        {
            return await this.quotesdetailRepository.All().ToListAsync();
        }

        public QuotesDetail GetById(int id)
        {
            var quotesdetail = this.quotesdetailRepository.Find(id);
            if (quotesdetail == null) throw new KeyNotFoundException("not found");
            return quotesdetail;
        }

        public async Task<bool> DeleteQuotesDetailAsync(int id)
        {
            try
            {
                var quotesdetail = this.GetById(IdQuoteDetail);
                this.quotesdetailRepository.Delete(quotesdetail);
                await this.quotesdetailRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<QuotesDetail> UpdateQuotesDetailAsync(QuotesDetail quotesdetail)
        {
            try
            {
                var quotesdetailToEdit = this.GetById(quotesdetail.IdQuoteDetail);
                quotesdetailToEdit.IdCustomer = quotesdetail.IdCustomer;
                quotesdetailToEdit.IdProvider = quotesdetail.IdProvider;
                quotesdetailToEdit.Line = quotesdetail.Line;
                quotesdetailToEdit.IdProduct = quotesdetail.IdProduct;
                quotesdetailToEdit.Price = quotesdetail.Price;
                quotesdetailToEdit.Amount = quotesdetail.Amount;
                quotesdetailToEdit.IStatus = quotesdetail.IStatus;

                var result = this.quotesdetailRepository.Update(quotesdetailToEdit);
                await this.quotesdetailRepository.SaveChangesAsync();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<QuotesDetail> CreateQuotesDetailAsync(QuotesDetail quotesdetail)
        {
            if (quotesdetail != null)
            {
                var newQuotesDetail = new QuotesDetail 
                {
                    IdCustomer = quotesdetail.IdCustomer,
                    IdProvider = quotesdetail.IdProvider,
                    Line = quotesdetail.Line,
                    IdProduct = quotesdetail.IdProduct,
                    Price = quotesdetail.Price,
                    Amount = quotesdetail.Amount,
                    IStatus = quotesdetail.IStatus,
                  
                };

                var result = this.quotesdetailRepository.Create(newQuotesDetail);
                await this.quotesdetailRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
