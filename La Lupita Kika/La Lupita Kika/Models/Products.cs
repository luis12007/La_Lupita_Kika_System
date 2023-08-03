using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Products
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public float Valor { get; set; }

        public string Tipo { get; set; }

        public string Codebar { get; set; }

        public float Cuantitydb { get; set; }

        public float Numberadd { get; set; }

        public int Subsidiary_id { get; set; }

        public string catego { get; set; }
        // Constructor vacío
        public Products()
        {
            // No hace falta inicializar los campos aquí, ya que C# asigna automáticamente los valores predeterminados
            // para los tipos de datos (null para referencia y 0 para numéricos) al crear una instancia de la clase.
        }

        // Constructor con parámetros
        public Products(string name, int cuantity, float valor, string tipo, string codebar)
        {
            Nombre = name;
            Cantidad = cuantity;
            Valor = valor;
            Tipo = tipo;
            Codebar = codebar;
        }

        public Products(string name, int cuantity, float valor, string tipo, string codebar,float cuantitydb, float numberadd)
        {
            Nombre = name;
            Cantidad = cuantity;
            Valor = valor;
            Tipo = tipo;
            Codebar = codebar;
            Cuantitydb = cuantitydb;
            Numberadd = numberadd;
        }

        public Products(string name, int cuantity, float valor, string tipo, string codebar, float cuantitydb, float numberadd, int subsidiary_id)
        {
            Nombre = name;
            Cantidad = cuantity;
            Valor = valor;
            Tipo = tipo;
            Codebar = codebar;
            Cuantitydb = cuantitydb;
            Numberadd = numberadd;
            Subsidiary_id = subsidiary_id;
        }
    }
}