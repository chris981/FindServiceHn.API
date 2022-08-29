using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.DepartmentsManager
{
    public class DepartmentsDTO
    {
        public int IdCountry { get; set; }
        public int IdDepartment { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IdUserCreation { get; set; }
        public string Condition { get; set; }
    }
}
