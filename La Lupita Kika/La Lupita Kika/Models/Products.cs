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
    }
}