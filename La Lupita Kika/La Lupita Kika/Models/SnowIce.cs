using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class SnowIce
    {
        public int SnowIce_id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Codebar { get; set; }

        public float Cuantity { get; set; }

        public int Subsidiary_ID { get; set; }

        public SnowIce() { }

        public SnowIce(int snowIceId, string name, float price, string codebar, float cuantity, int subsidiary_ID)
        {
            SnowIce_id = snowIceId;
            Name = name;
            Price = price;
            Codebar = codebar;
            Cuantity = cuantity;
            Subsidiary_ID = subsidiary_ID;
        }

        public SnowIce(string name, float price, string codebar, float cuantity, int subsidiary_ID)
        {
            Name = name;
            Price = price;
            Codebar = codebar;
            Cuantity = cuantity;
            Subsidiary_ID = subsidiary_ID;
        }
    }

}
