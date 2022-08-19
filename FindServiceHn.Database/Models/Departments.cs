using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Models
{
    public class Departments
    {
        public int IdCountry { get; set; }
        public int IdDepartment { get; set; }
        public string Description { get; set; }
        public int IdUserCreation { get; set; }
        public string Condition { get; set; }
    }
}
