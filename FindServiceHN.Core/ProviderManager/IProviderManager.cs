using FindServiceHn.Database.Models;
using FindServiceHN.Core.Models;
using FindServiceHN.Core.ProviderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ProviderManager
{
    public interface IProviderManager
    {
        #region"provider "
        Task<IEnumerable<Provider>> GetAllAsync();
        Task<Provider> CreateProviderAsync(ProviderDTO provider);
        Task<bool> DeleteProviderAsync(int id);
        Task<Provider> UpdateProviderAsync(Provider provider);
        Provider GetById(int id);
        #endregion

        #region"providerplanjob"
        Task<IEnumerable<ProviderPlanJob>> GetProviderPlanJobAsync();
        Task<ProviderPlanJob> CreateProviderPlanJobAsync(ProviderPlanJobDTO providerPlanJob);

        Task<bool> DeleteProviderPlanJobAsync(int id);
        Task<ProviderPlanJob> UpdateProviderPlanJobAsync(ProviderPlanJob providerPlanJob);
        ProviderPlanJob GetProviderPlanJobById(int id);
        #endregion

        #region"provider service"
        Task<IEnumerable<ProviderService>> GetAllProviderServiceAsync();
        Task<ProviderService> CreateProviderServiceAsync(ProviderServiceDTO providerService);
        Task<bool> DeleteProviderServiceAsync(int id);
        Task <ProviderService> UpdateProviderServiceAsync(ProviderService providerService);
        ProviderService GetProviderServiceById(int id);
        #endregion

        #region"providerEval"
        Task<IEnumerable<ProviderEval>> GetProviderEvalAsync();
        Task <ProviderEval> CreateProviderEvalAsync(ProviderEvalDTO providerEval);

        Task<bool>DeleteProviderEvalAsync(int id);

        Task<ProviderEval> UpdateProviderEvalAsync(ProviderEval providerEval);

        ProviderEval GetProviderEvalById(int id);
        #endregion
    }
}
