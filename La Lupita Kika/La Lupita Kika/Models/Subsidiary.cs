using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Subsidiary
    {
        public int Subsidiary_ID { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }

        public Subsidiary()
        {
        }

        public Subsidiary(string name, string place, string address)
        {
            Name = name;
            Place = place;
            Address = address;
        }

        public Subsidiary(int subsidiaryId, string name, string place, string address)
        {
            Subsidiary_ID = subsidiaryId;
            Name = name;
            Place = place;
            Address = address;
        }
    }
}
