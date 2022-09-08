using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ProviderManager
{
    public class ProviderEvalDTO
    {
        public string Email { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public int Phone { get; set; }
        public int Idcategory { get; set; }
        public string Observation { get; set; }
        public int IdStatus { get; set; }
    }
}
