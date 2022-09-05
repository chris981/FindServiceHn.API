using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CustomersManager
{
    public class CustomersDTO
    {
        public string emailpassword { get; set; }
        public int Rtn { get; set; }
        public int Identificationcard { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdCustomerAddress { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Municipality { get; set; }
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }
        public string Status { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string MainProfile { get; set; }
        public string KeyValidation { get; set; }
        public string UserType { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
