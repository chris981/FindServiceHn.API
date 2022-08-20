using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderDetailManager
{
	public class OrderDetailManager : IOrderDetailManager
	{
        private readonly IRepository<OrderDetail> OrderDetailRepository;

        public OrderDetailManager(IRepository<OrderDetail> OrderDetailRepository)
        {
            this.OrderDetailRepository = OrderDetailRepository;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await this.OrderDetailRepository.All().ToListAsync();
        }
    }
}
