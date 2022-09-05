using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindServiceHN.Core.ProvidersAttentionManager
{
    public class ProvidersAttentionDTO
    {
     public string Description {get; set;}
     public string TypeAttention {get; set;}
     public int IdStatus {get; set;}
     public DateTime CreationDate {get; set;}
    }
}