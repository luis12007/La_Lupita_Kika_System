using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Invest
    {
        public int Invest_id { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }

        public Invest() { }

        public Invest(int investId, DateTime date, float price)
        {
            Invest_id = investId;
            Date = date;
            Price = price;
        }
    }

}
