using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CustomerAddressManager
{
    public class CustomerAddressDTO
    {
        public int IdCustomerAddress { get; set; }
        public int IdCustomer { get; set; }
        public int IdCountry { get; set; }
        public int IdDeparment { get; set; }
        public int IdMunicipality { get; set; }
        public string Direction { get; set; }
        public string Observations { get; set; }
        public int idStatus { get; set; }
    }
}
