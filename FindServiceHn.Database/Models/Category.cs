using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Models
{
    public class Category
    {
        public int IdCategory { get; set; }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int IdStatus { get; set; }
        public string Image { get; set; }
    }
}
