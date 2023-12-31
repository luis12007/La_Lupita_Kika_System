﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Palettes
    {
        public int Palette_id { get; set; }
        public string Name { get; set; }
        public int Category_Id { get; set; }
        public float Price { get; set; }
        public string Codebar { get; set; }
        public string Codigo { get; set; }

        public float Cuantity { get; set; }

        public int Subsidiary_ID { get; set; }

        public Palettes() { }

        public Palettes(int paletteId, string name, int categoryId, float price, string codebar, string codigo, float cuantity, int subsidiary_ID)
        {
            Palette_id = paletteId;
            Name = name;
            Category_Id = categoryId;
            Price = price;
            Codebar = codebar;
            Codigo = codigo;
            Cuantity = cuantity;
            Subsidiary_ID = subsidiary_ID;
        }

        public Palettes( string name, int categoryId, float price, string codebar, string codigo, float cuantity, int subsidiary_ID)
        {
            Name = name;
            Category_Id = categoryId;
            Price = price;
            Codebar = codebar;
            Codigo = codigo;
            Cuantity = cuantity;
            Subsidiary_ID = subsidiary_ID;
        }
    }
}
