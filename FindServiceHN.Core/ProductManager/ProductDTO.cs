using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ProductManager
{
    public class ProductDTO
    {
        public int IdProvider { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string CurrencyName { get; set; }
        public double Price { get; set; }
        public string ShippingStatus { get; set; }
    }
}
