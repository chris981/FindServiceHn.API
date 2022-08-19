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
        private readonly IRepository<Order_detail> OrderDetailRepository;

        public OrderDetailManager(IRepository<Order_detail> OrderDetailRepository)
        {
            this.OrderDetailRepository = OrderDetailRepository;
        }

        public async Task<IEnumerable<Order_detail>> GetAllAsync()
        {
            return await this.OrderDetailRepository.All().ToListAsync();
        }
    }
}
