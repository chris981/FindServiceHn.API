using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Models
{
    public class OrderHeader
    {
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }
        public int IdProvider { get; set; }
        public int IdClientAddress { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public int IdSubCategory { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int IdStatus { get; set; }
        public int SatisfactionLevel { get; set; }
        public string CustomerObservation { get; set; }

    }
}
