using FindServiceHn.Database.Models;
using FindServiceHN.Core.Models;
using FindServiceHN.Core.OrderDetailManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderDetailManager
{
	public interface IOrderDetailManager
	{
        IEnumerable<OrderDetail> GetAll();
        Task<OrderDetail> CreateOrderDetailAsync(OrderDetailDTO orderDetail);
        Task<bool> DeleteOrderDetailAsync(int id);
        Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail);
        OrderDetail GetById(int id);
    }
}
