using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderDetailManager
{
    public class OrderDetailDTO
    {
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }
        public int IdProvider { get; set; }
        public string Line { get; set; }
        public int IdProduct { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int IdStatus { get; set; }
    }
}
