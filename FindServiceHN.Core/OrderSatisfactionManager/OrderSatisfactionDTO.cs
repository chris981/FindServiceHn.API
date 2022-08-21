using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderSatisfactionManager
{
    public class OrderSatisfactionDTO
    {
        public int IdSatisfaction { get; set; }
        public int Valorization { get; set; }
        public string Description { get; set; }
    }
}
