using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Mangoneadas
    {
        public int Mangoneadas_id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Codebar { get; set; }
        public string Code { get; set; }
        public int Category_id { get; set; }

        public float Cuantity { get; set; }

        public int Subsidiary_ID { get; set; }

        public Mangoneadas() { }

        public Mangoneadas(int mangoneadasId, string name, float price, string codebar, string code, int categoryId, float cuantity, int subsidiary_ID)
        {
            Mangoneadas_id = mangoneadasId;
            Name = name;
            Price = price;
            Codebar = codebar;
            Code = code;
            Category_id = categoryId;
            Cuantity = cuantity;
            Subsidiary_ID = subsidiary_ID;
        }
    }
}
