using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Snowxingredients
    {
        public int SnowxIngredients_id { get; set; }
        public int Ingredients_id { get; set; }
        public int Snow_id { get; set; }

        public Snowxingredients() { }

        public Snowxingredients(int snowxIngredientsId, int ingredientsId, int snowId)
        {
            SnowxIngredients_id = snowxIngredientsId;
            Ingredients_id = ingredientsId;
            Snow_id = snowId;
        }
    }
}
