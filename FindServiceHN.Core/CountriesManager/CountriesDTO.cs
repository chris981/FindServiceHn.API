using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CountriesManager
{
    public class CountriesDTO
    {
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public int IdStatus { get; set; }
        public int IdUserCreation { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
