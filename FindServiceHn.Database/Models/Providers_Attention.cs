using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindServiceHn.Database.Models
{
    public class Providers_Attention
    {
     public int IdProviderAttention {get; set;}
     public string Description {get; set;}
     public string TypeAttention {get; set;}
     public int IStatus {get; set;}
     public DateTime CreationDate {get; set;}
        
    }
}