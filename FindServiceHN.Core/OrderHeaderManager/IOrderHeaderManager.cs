using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderHeaderManager
{
    public interface IOrderHeaderManager
    {
        Task<IEnumerable<OrderHeader>> GetAllAsync();
        Task<OrderHeader> CreateOrderHeaderAsync(OrderHeaderDTO orderHeader);
        Task<bool> DeleteOrderHeaderAsync(int id);
        Task<OrderHeader> UpdateOrderHeaderAsync(OrderHeader orderHeader);
        OrderHeader GetById(int id);
    }
}
