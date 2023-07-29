using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class CategoryC
    {
        public int CategoryD_ID { get; set; }
        public string Name { get; set; }

        public CategoryC() { }

        public CategoryC(int categoryDId, string name)
        {
            CategoryD_ID = categoryDId;
            Name = name;
        }
    }

}
