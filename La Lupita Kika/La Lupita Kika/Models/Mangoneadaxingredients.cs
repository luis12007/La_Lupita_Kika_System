using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Mangoneadaxingredients
    {
        public int Mangoneaxin_id { get; set; }
        public int Ingredients_id { get; set; }
        public int Mangoneada_id { get; set; }

        public Mangoneadaxingredients() { }

        public Mangoneadaxingredients(int mangoneaxinId, int ingredientsId, int mangoneadaId)
        {
            Mangoneaxin_id = mangoneaxinId;
            Ingredients_id = ingredientsId;
            Mangoneada_id = mangoneadaId;
        }
    }
}
