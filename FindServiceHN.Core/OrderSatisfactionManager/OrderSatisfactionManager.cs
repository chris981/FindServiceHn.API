using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderSatisfactionManager
{
	public class OrderSatisfactionManager : IOrderSatisfactionManager
	{
        private readonly IRepository<OrderSatisfaction> OrderSatisfactionRepository;

        public OrderSatisfactionManager(IRepository<OrderSatisfaction> OrderSatisfactionRepository)
        {
            this.OrderSatisfactionRepository = OrderSatisfactionRepository;
        }

        public async Task<IEnumerable<OrderSatisfaction>> GetAllAsync()
        {
            return await this.OrderSatisfactionRepository.All().ToListAsync();
        }
    }
}
