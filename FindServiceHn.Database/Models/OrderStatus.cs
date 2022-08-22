using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Models
{
	public class OrderStatus
	{
		public int IdStatusOrder { get; set; }
		public int IdStatus { get; set; }
		public string Description { get; set; }
	}
}
