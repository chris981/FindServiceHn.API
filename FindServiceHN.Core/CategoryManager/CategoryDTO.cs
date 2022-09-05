using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CategoryManager
{
    public class CategoryDTO
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdUserCreation { get; set; }
        public int IdStatus { get; set; }
        public string Image { get; set; }
    }
}
