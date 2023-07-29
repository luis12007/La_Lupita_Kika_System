using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Investxingredients
    {
        public int SnowXin_id { get; set; }
        public int Ingredients_id { get; set; }
        public int Invest_id { get; set; }

        public Investxingredients() { }

        public Investxingredients(int snowXinId, int ingredientsId, int investId)
        {
            SnowXin_id = snowXinId;
            Ingredients_id = ingredientsId;
            Invest_id = investId;
        }
    }
}
