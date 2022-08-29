using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.MunicipalitiesManager
{
    public class MunicipalitiesDTO
    {
        public int IdCountry { get; set; }
        public int IdDeparment { get; set; }
        public int IdMunicipality { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdUserCreation { get; set; }
        public int IdStatus { get; set; }
    }
}
