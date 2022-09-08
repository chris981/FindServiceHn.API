using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindServiceHn.Database.Models
{
    public class QuotesHeader
    {
         public int IdQuoteHeader {get; set;}
         public int IdQuoteDetail {get; set;}

         public int IdCustomer {get; set;}
         public int IdProvider {get; set;}
         public int IdClientAddres {get; set;}
         public string Description {get; set;}
         public int IdCategory {get; set;}

         public int IdSubcategory {get; set;}
         public DateTime CreationDate {get; set;}
         public string AssigmentDate {get; set;}
         public int IdStatus {get; set;}
         public string CustomerObservation {get; set;}
         public string ProviderObservation {get; set;}
         public int IdStatusCreationDate {get; set;}

    }
}