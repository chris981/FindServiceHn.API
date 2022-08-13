using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Models
{
    public class Countries
    {
        public int IdCountry { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public int IdStatus { get; set; }
        public int IdUserCreation { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
