using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Ingredients
    {
        public int Ingredients_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public float Price { get; set; }
        public float Unit { get; set; }
        public string Type { get; set; }

        public int Subsidiary_ID { get; set; }

        public string Category { get; set; }

        public Ingredients() { }

        public Ingredients(int ingredientsId, string name, string code, float price, float unit, string type, int subsidiary_ID, string category)
        {
            Ingredients_id = ingredientsId;
            Name = name;
            Code = code;
            Price = price;
            Unit = unit;
            Type = type;
            Subsidiary_ID = subsidiary_ID;
            Category = category;
        }


    }

}
