using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    internal class Other
    {
            public int Others_id { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
            public string Codebar { get; set; }

            public Other() { }

            public Other(int othersid, string name, float price, string codebar)
            {
                Others_id = othersid;
                Name = name;
                Price = price;
                Codebar = codebar;
            }
        public Other(string name, float price, string codebar)
        {
            Name = name;
            Price = price;
            Codebar = codebar;
        }

    }
}
