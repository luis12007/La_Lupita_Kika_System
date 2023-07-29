using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Register
    {
        public int Register_id { get; set; }
        public DateTime Inhour { get; set; }
        public TimeSpan? Outhour { get; set; }
        public float? Daygains { get; set; }
        public int User_id { get; set; }

        // Constructor para la obtención desde la base de datos
        public Register(int registerId, DateTime inhour, TimeSpan? outhour, float? daygains, int userId)
        {
            Register_id = registerId;
            Inhour = inhour;
            Outhour = outhour;
            Daygains = daygains;
            User_id = userId;
        }

        // Constructor para agregar nuevos registros (sin el id, ya que la base de datos lo generará)
        public Register(DateTime inhour, TimeSpan? outhour, float? daygains, int userId)
        {
            Inhour = inhour;
            Outhour = outhour;
            Daygains = daygains;
            User_id = userId;
        }
    }
}