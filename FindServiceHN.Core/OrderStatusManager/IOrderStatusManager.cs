using FindServiceHn.Database.Models;
using FindServiceHN.Core.OrderStatusManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderStatusManager
{
	public interface IOrderStatusManager
	{
        Task<IEnumerable<OrderStatus>> GetAllAsync();
        Task<OrderStatus> CreateOrderStatusAsync(OrderStatusDTO orderStatus);
        Task<bool> DeleteOrderStatusAsync(int id);
        Task<OrderStatus> UpdateOrderStatusAsync(OrderStatus orderStatus);
        OrderStatus GetById(int id);
    }
}
