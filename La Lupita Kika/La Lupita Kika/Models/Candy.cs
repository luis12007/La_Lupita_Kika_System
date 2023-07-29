using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Candy
    {
        public int Candy_id { get; set; }
        public string Name { get; set; }
        public int Category_id { get; set; }
        public float Price { get; set; }
        public string Codebar { get; set; }

        public Candy() { }

        public Candy(int candyId, string name, int categoryId, float price, string codebar)
        {
            Candy_id = candyId;
            Name = name;
            Category_id = categoryId;
            Price = price;
            Codebar = codebar;
        }

        public Candy( string name, int categoryId, float price, string codebar)
        {
            Name = name;
            Category_id = categoryId;
            Price = price;
            Codebar = codebar;
        }
    }
}
