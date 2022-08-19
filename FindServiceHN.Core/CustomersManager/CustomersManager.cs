using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CustomersManager
{
    public class CustomersManager : ICustomersManager
    {
        private readonly IRepository<Customers> CustomersRepository;

        public CustomersManager(IRepository<Customers> CustomerRepository)
        {
            this.CustomersRepository = CustomerRepository;
        }
        public async Task<IEnumerable<Customers>> getAllAsync()
        {
            return await this.CustomersRepository.All().ToListAsync();
        }
    }
}
