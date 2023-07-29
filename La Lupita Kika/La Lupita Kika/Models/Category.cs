using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public Category() { }

        public Category(int categoryId, string name)
        {
            CategoryID = categoryId;
            Name = name;
        }
    }

}
