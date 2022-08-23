using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ServicesStatusManager
{
    public interface IServicesStatusManager
    {
        Task<IEnumerable<ServicesStatus>> GetAllAsync();

        Task<ServicesStatus> CreateServicesStatusAsync(ServicesStatusDTO servicesstatus);
        Task<bool> DeleteServicesStatusAsync(int IdServicesStatus);
        Task<ServicesStatus> UpdateServicesStatusAsync(ServicesStatus servicesstatus);
        ServicesStatus GetById(int IdServicesStatus);

    }
}
