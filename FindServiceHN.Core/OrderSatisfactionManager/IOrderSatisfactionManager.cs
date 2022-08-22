using FindServiceHn.Database.Models;
using FindServiceHN.Core.Models;
using FindServiceHN.Core.OrderSatisfactionManager;
using FindServiceHN.Core.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderSatisfactionManager
{
	public interface IOrderSatisfactionManager
	{
        IEnumerable<OrderSatisfaction> GetAll();
        Task<OrderSatisfaction> CreateOrderSatisfactionAsync(OrderSatisfactionDTO orderSatisfaction);
        Task<bool> DeleteOrderSatisfactionAsync(int id);
        Task<OrderSatisfaction> UpdateOrderSatisfactionAsync(OrderSatisfaction orderSatisfaction);
        OrderSatisfaction GetById(int id);
    }
}
