using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderStatusManager
{
	public class OrderStatusManager : IOrderStatusManager
	{
        private readonly IRepository<OrderStatus> OrderStatusRepository;

        public OrderStatusManager(IRepository<OrderStatus> OrderStatusRepository)
        {
            this.OrderStatusRepository = OrderStatusRepository;
        }

        public async Task<IEnumerable<OrderStatus>> GetAllAsync()
        {
            return await this.OrderStatusRepository.All().ToListAsync();
        }
    }
}
