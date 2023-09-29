using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views
{
    public partial class Warning : Form
    {
        private string ConnectionString;
        private List<Models.Products> productosFaltantesList = new List<Models.Products>(); // Lista de productos que faltan
        private string tittle;
        public Warning(string connectionString, List<Models.Products> productosFaltantesList, string tittle)
        {
            this.ConnectionString = connectionString;
            InitializeComponent();
            InitializeDataGridView();
            this.productosFaltantesList = productosFaltantesList;
            this.tittle = tittle;
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void Warning_Load(object sender, EventArgs e)
        {
            tittle_label.Text = tittle;


            var groupedProducts = productosFaltantesList
                .GroupBy(palettec => new { palettec.Nombre, palettec.Tipo, palettec.Codebar, palettec.Cantidad })
                .Select(group => new Models.Products(
                    group.First().Nombre,
                    group.Key.Cantidad,
                    group.Sum(p => p.Valor),
                    group.Key.Tipo,// Sumar los valores
                    "none" // Tomar el código de barras del primer elemento del grupo
                ));

            string subsidiary = "juayua";
            float number = 0;
            string type;

            foreach (var palettec in groupedProducts)
            {
                if (palettec.Cantidad == 2)
                {
                    subsidiary = "Juayua";
                }
                else if (palettec.Cantidad == 1)
                {
                    subsidiary = "Sonsonate";
                }

                number = palettec.Valor;
                type = palettec.Tipo;


                if (palettec.Nombre == "Alguashte")
                {
                    number = number * 0.0326f;
                    type = "LIBRAS";
                }
                else if (palettec.Nombre == "Chile liquido")
                {
                    number = number * 0.003906f;
                    type = "GALON";
                }
                else if (palettec.Nombre == "Arrayán")
                {
                    number = number / 6f;
                    type = "LIBRAS";
                }else if (palettec.Nombre == "Servilleta")
                {
                    type = "PAQUETES";
                    number = number / 40f;
                }

                switch (type)
                {

                    case "TBSP":
                        number = number * 0.0326f;
                        type = "LIBRA";
                        break;

                    case "TBS":
                        number = number * 0.0326f;
                        type = "LIBRA";
                        break;

                    /*case "GRAMOS":
                        number = number * 0.0022f;
                        type = "LIBRA";
                        break;*/

                    default: break;
                }

                // Redondear el número a dos decimales
                float roundedNumber = (float)Math.Round(number, 2);

                // Si el número redondeado es 0.00, mostrar un decimal más
                if (roundedNumber == 0.00f)
                {
                    roundedNumber = (float)Math.Round(number, 4);
                }


                // Crear un nuevo String[] con los valores de cada elemento en la lista
                String[] row2 = { palettec.Nombre, $"{roundedNumber}", $"{type}", $"{subsidiary}" };

                // Agregar el nuevo String[] a Products_dataGridView.Rows
                Products_dataGridView.Rows.Add(row2);
                Products_dataGridView.ClearSelection();
            }

        }

        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            Products_dataGridView.ColumnCount = 4;      // Columna para el nombre del producto
            Products_dataGridView.Columns[0].Name = "Nombre";
            Products_dataGridView.Columns[1].Name = "Cantidad";
            Products_dataGridView.Columns[2].Name = "Tipo";
            Products_dataGridView.Columns[3].Name = "Sucursal";

            // Ajustar el ancho de las columnas
            Products_dataGridView.Columns["Nombre"].Width = 277;
            Products_dataGridView.Columns["Cantidad"].Width = 100;
            Products_dataGridView.Columns["tipo"].Width = 110;
            Products_dataGridView.Columns["Sucursal"].Width = 120;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
