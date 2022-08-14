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
    public class Providers_AttentionManager : IProviders_AttentionManager
    {
         private readonly IRepository<Providers_Attention> providers_attentionRepository;

        public Providers_AttentionManager(IRepository<Providers_Attention> providers_attentionRepository)
        {
            this.providers_attentionRepository = providers_attentionRepository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await this.providers_attentionRepository.All().ToListAsync();
        }
    }
}