using FindServiceHn.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ProviderManager
{
    public class ProviderDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int RTN { get; set; }
        public string Company { get; set; }
        public int IdentificationCard { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Municipality { get; set; }
        public int Phone { get; set; }
        public int IdCategory { get; set; }
        public int IdSubcategory { get; set; }
        public string IndusCai { get; set; }
        public string IndDelivery { get; set; }
        public string AtentionFirst { get; set; }
        public string AtentionLast { get; set; }
        public int IdStatus { get; set; }
        public string ProfilePicture { get; set; }
        public string ProfilePrincipal { get; set; }
        public string Url { get; set; }
        public string QtyWorks { get; set; }
        public int KeyValidation { get; set; }
        public string UserType { get; set; }
    }
}

