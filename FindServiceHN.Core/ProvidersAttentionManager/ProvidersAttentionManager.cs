using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindServiceHN.Core.ProvidersAttentionManager
{
    public class ProvidersAttentionManager : IProvidersAttentionManager
    {
         private readonly IRepository<ProvidersAttention> providersattentionRepository;

        public ProvidersAttentionManager(IRepository<ProvidersAttention> providersattentionRepository, IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            this.providersattentionRepository = providersattentionRepository;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<ProvidersAttention>> GetAllAsync()
        {
            return await this.providersattentionRepository.All().ToListAsync();
        }

        public ProvidersAttention GetById(int id)
        {
            var providersattention = this.providersattentionRepository.Find(id);
            if (providersattention == null) throw new KeyNotFoundException("not found");
            return providersattention;
        }

        public async Task<bool> DeleteProvidersAttentionAsync(int id)
        {
            try
            {
                var providersattention = this.GetById(id);
                this.providersattentionRepository.Delete(providersattention);
                await this.providersattentionRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<ProvidersAttention> UpdateProvidersAttentionAsync(ProvidersAttention providersattention)
        {
            try
            {
                var providersattentionToEdit = this.GetById(providersattention.IdProviderAttention);
                providersattentionToEdit.Description = providersattentionToEdit.Description;
                providersattentionToEdit.TypeAttention = providersattentionToEdit.TypeAttention;
                providersattentionToEdit.IStatus = providersattentionToEdit.IStatus;
                providersattentionToEdit.CreationDate = providersattentionToEdit.CreationDate;
                

                var result = this.providersattentionRepository.Update(providersattentionToEdit);
                await this.providersattentionRepository.SaveChangesAsync();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<ProvidersAttention> CreateProvidersAttentionAsync(ProvidersAttentionDTO providersattention)
        {
            if (providersattention != null)
            {
                var newProvidersAttention = new ProvidersAttention 
                {
                    Description = providersattention.Description,
                    TypeAttention = providersattention.TypeAttention,
                    IStatus = providersattention.IStatus,
                    CreationDate = providersattention.CreationDate,
                    
                };

                var result = this.providersattentionRepository.Create(newProvidersAttention);
                await this.providersattentionRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}