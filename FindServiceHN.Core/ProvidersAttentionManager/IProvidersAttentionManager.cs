using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ProvidersAttentionManager
{
    public interface IProvidersAttentionManager
    {
        
        Task<IEnumerable<ProvidersAttention>> GetAllAsync();
        Task<ProvidersAttention> CreateProvidersAttentionAsync(ProvidersAttentionDTO providersattention);
        Task<bool> DeleteProvidersAttentionAsync(int id);
        Task<ProvidersAttention> UpdateProvidersAttentionAsync(ProvidersAttention providersattention);
        ProvidersAttention GetById(int id);
    
    }
}