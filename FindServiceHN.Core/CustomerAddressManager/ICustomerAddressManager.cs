using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CustomerAddressManager
{
    public interface ICustomerAddressManager
    {
        Task<IEnumerable<CustomerAddressManager>> GetAllAsync();
    }
}
