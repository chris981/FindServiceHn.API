using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderStatusManager
{
    public class OrderStatusDTO
    {
        public int IdStatusOrder { get; set; }
        public int IdStatus { get; set; }
        public string Description { get; set; }
    }
}
