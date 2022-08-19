using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Models
{


    public class ProviderPlanJob
    {
        public int IdQtyWorks { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int CreationDate { get; set; }
    }
}