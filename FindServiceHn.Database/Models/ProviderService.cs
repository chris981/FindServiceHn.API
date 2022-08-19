using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Models
{

    public class ProviderService
    {
        public int IdProviderService { get; set; }
        public string Product { get; set; }
        public int IdServiceType { get; set; }
        public string TypeService { get; set; }
        public string Description { get; set; }
        public int Currency { get; set; }
        public int Price { get; set; }
        public int Shipping { get; set; }
        public string ProductImage { get; set; }
        public string IStatus { get; set; }
    }
}