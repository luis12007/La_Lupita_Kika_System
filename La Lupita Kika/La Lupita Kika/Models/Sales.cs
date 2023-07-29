using System;

namespace La_Lupita_Kika.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Lot { get; set; }
        public float Total { get; set; }

        public Sales() { } // Constructor por defecto

        public Sales(int id, string name, float lot, float total)
        {
            Id = id;
            Name = name;
            Lot = lot;
            Total = total;
        }

        public Sales(string name, float lot, float total)
        {
            Name = name;
            Lot = lot;
            Total = total;
        }
    }
}
