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
        private readonly IRepository<Order_satisfaction> OrderSatisfactionRepository;

        public OrderSatisfactionManager(IRepository<Order_satisfaction> OrderSatisfactionRepository)
        {
            this.OrderSatisfactionRepository = OrderSatisfactionRepository;
        }

        public async Task<IEnumerable<Order_satisfaction>> GetAllAsync()
        {
            return await this.OrderSatisfactionRepository.All().ToListAsync();
        }
    }
}
