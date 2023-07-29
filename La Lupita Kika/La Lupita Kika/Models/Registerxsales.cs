using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Registerxsales
    {
        public int List_id { get; set; }
        public int Register_id { get; set; }
        public int Sales_id { get; set; }

        public Registerxsales() { }

        public Registerxsales(int registerId, int salesId)
        {
            Register_id = registerId;
            Sales_id = salesId;
        }
    }
}
