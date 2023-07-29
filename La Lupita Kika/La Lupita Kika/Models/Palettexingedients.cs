using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Palettexingedients
    {
        public int Palettexin_id { get; set; }
        public int Ingredients_id { get; set; }
        public int Palette_id { get; set; }

        public Palettexingedients() { }

        public Palettexingedients(int palettexinId, int ingredientsId, int paletteId)
        {
            Palettexin_id = palettexinId;
            Ingredients_id = ingredientsId;
            Palette_id = paletteId;
        }
    }
}
