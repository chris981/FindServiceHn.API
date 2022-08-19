using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CustomerAddressManager
{
    public class CustomerAddressManager : ICustomerAddressManager
    {
        private readonly IRepository<CustomerAddressManager> CustomerAddressRepository;

        public CustomerAddressManager(IRepository<CustomerAddressManager> CustomerAddressRepository)
        {
            this.CustomerAddressRepository = CustomerAddressRepository;  
        }
        public async Task<IEnumerable<CustomerAddressManager>> GetAllAsync()
        {
            return await this.CustomerAddressRepository.All().ToListAsync();
        }
    }
}
