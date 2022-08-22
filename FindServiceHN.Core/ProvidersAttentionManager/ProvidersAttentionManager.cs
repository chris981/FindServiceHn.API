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

        public ProvidersAttentionManager(IRepository<ProvidersAttention> providersattentionRepository)
        {
            this.providersattentionRepository = providersattentionRepository;
        }

        public async Task<IEnumerable<ProvidersAttention>> GetAllAsync()
        {
            return await this.providersattentionRepository.All().ToListAsync();
        }
    }
}