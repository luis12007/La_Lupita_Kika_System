using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Rol
    {
        public int Rol_id { get; set; }
        public string Name { get; set; }

        public Rol() { }

        public Rol(int rolId, string name)
        {
            Rol_id = rolId;
            Name = name;
        }
    }

}
