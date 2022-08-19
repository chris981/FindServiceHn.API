using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderSatisfactionManager
{
	public interface IOrderSatisfactionManager
	{
		Task<IEnumerable<Order_satisfaction>> GetAllAsync();
	}
}
