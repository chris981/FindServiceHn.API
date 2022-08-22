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
<<<<<<< HEAD
        Task<ServicesStatus> CreateServicesStatusAsync(ServicesStatusDTO servicesstatus);
        Task<bool> DeleteServicesStatusAsync(int IdServicesStatus);
        Task<ServicesStatus> UpdateUserAsync(ServicesStatus servicesstatus);
        User GetById(int IdServicesStatus);
=======
>>>>>>> 4377ebe53d10aa63a2df4e60f81e3a1c0d1fb75e
    }
}
