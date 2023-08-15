using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Ingredients
{
    public partial class AddIngredients : Form
    {
        private string connection;

        private string Ingredient;
        private string category;
        private string productName;
        private int Number;
        private int subsidiaryint;
        private string Codebar;
        private string subsidiary;

        private SubsidiaryRepository subsidiaryrepo;
        private IngredientsRepository ingredientsrepo;

        private List<Models.Products> productosList = new List<Models.Products>(); // Lista de productos
        public AddIngredients(string connectionString)
        {
            InitializeComponent();
            this.connection = connection;
            this.subsidiaryrepo = new SubsidiaryRepository(connectionString);
            this.ingredientsrepo = new IngredientsRepository(connectionString);
            InitializeDataGridView();
        }

        private void Products_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddIngredients_Load(object sender, EventArgs e)
        {
            List<Subsidiary> subsidiary = subsidiaryrepo.GetAll();

            string[] subsidiaryNames = new string[subsidiary.Count];

            // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
            for (int i = 0; i < subsidiary.Count; i++)
            {
                subsidiaryNames[i] = subsidiary[i].Name;
            }

            Subsidiary_cbb.DataSource = subsidiaryNames;
            Subsidiary_cbb.SelectedIndex = 1;




        }

        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            Products_dataGridView.ColumnCount = 5;      // Columna para el nombre del producto
            Products_dataGridView.Columns[0].Name = "Nombre";
            Products_dataGridView.Columns[1].Name = "Cidigo";
            Products_dataGridView.Columns[2].Name = "Diferencia";
            Products_dataGridView.Columns[3].Name = "Tipo";
            Products_dataGridView.Columns[4].Name = "Sucursal";



            // Ajustar el ancho de las columnas
            Products_dataGridView.Columns["Nombre"].Width = 271;
            Products_dataGridView.Columns["Cidigo"].Width = 127;
            Products_dataGridView.Columns["Diferencia"].Width = 127;
            Products_dataGridView.Columns["Tipo"].Width = 127;
            Products_dataGridView.Columns["Sucursal"].Width = 120;

        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            if (Number_textbox.Texts == "" || ingredients_cbb.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Los campos no pueden estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Ingredient = ingredients_cbb.SelectedItem.ToString();
            Number = int.Parse(Number_textbox.Texts);
            subsidiary = Subsidiary_cbb.SelectedItem.ToString();
            subsidiaryint = subsidiaryrepo.FindIdByName(subsidiary);

            Models.Ingredients addingredient = ingredientsrepo.FindByNameAndSubsidiary(Ingredient, subsidiaryint);

            Models.Products existingProduct = productosList.FirstOrDefault(p =>
                        p.Nombre == addingredient.Name && p.Valor == addingredient.Price && p.Subsidiary_id == addingredient.Subsidiary_ID);

            if (existingProduct != null)
            {
                // Si existe un objeto igual, actualizar la cantidad a 2
                existingProduct.Cantidad += Number;
                existingProduct.Numberadd += Number;
            }
            else
            {
                // Si no existe un objeto igual, agregar el nuevo objeto a la lista

                Models.Products productpalette = new Models.Products(addingredient.Name, Number, addingredient.Price, "Paletas", addingredient.Code, addingredient.Unit, Number, addingredient.Subsidiary_ID, addingredient.Type);
                productosList.Add(productpalette);
            }

            Products_dataGridView.Rows.Clear();
            foreach (var palettec in productosList)
            {
                // Crear un nuevo String[] con los valores de cada elemento en la lista
                String[] row2 = { palettec.Nombre, palettec.Codebar,
                            $"{palettec.Cuantitydb} -> {palettec.Cuantitydb + palettec.Numberadd}", $"{palettec.catego}",$"{subsidiaryrepo.FindNameById(palettec.Subsidiary_id)}"  };

                // Agregar el nuevo String[] a Products_dataGridView.Rows
                Products_dataGridView.Rows.Add(row2);
                Products_dataGridView.ClearSelection();
            }
            Number_textbox.Texts = "";

        }

        private void Subsidiary_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            subsidiary = Subsidiary_cbb.SelectedItem.ToString();
            switch (subsidiary)
            {
                case "Sonsonate":
                    subsidiaryint = 2;
                    break;
                case "Juayua":
                    subsidiaryint = 1;
                    break;
                default:
                    break;
            }
        }

        private void Products_dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                // Eliminar la fila del DataGridView

                string nombreProducto = Products_dataGridView.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                Models.Products productoEncontrado = productosList.FirstOrDefault(p => p.Nombre == nombreProducto);

                //---------------------------------------------------------------

                productosList.RemoveAll(p => p.Nombre == nombreProducto);

                Products_dataGridView.Rows.RemoveAt(e.RowIndex);

                Products_dataGridView.ClearSelection();
                Products_dataGridView.Refresh();
            }
        }

        private void Process_button_Click(object sender, EventArgs e)
        {
            if (productosList.IsNullOrEmpty())
            {
                MessageBox.Show("Sin productos para procesar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (Models.Products producto in productosList)
            {
                ingredientsrepo.EditUnitByNameAndSubsidiaryId(producto.Nombre, producto.Subsidiary_id, producto.Cantidad);
            }
            MessageBox.Show("Agreagdo correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Products_dataGridView.Rows.Clear();
            Products_dataGridView.Refresh();
            productosList.Clear();

            this.Close();

        }

        private void Category_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            category = Category_cbb.SelectedItem.ToString();
            switch (category)
            {
                case "Fruta":
                    List<Models.Ingredients> ingredients = ingredientsrepo.FindBySubsidiaryAndCategory(2, "Fruta");

                    ingredients.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));

                    string[] ingredientsnames = new string[ingredients.Count];

                    // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
                    for (int i = 0; i < ingredients.Count; i++)
                    {
                        ingredientsnames[i] = ingredients[i].Name;
                    }

                    ingredients_cbb.DataSource = ingredientsnames;
                    break;
                case "Emboltorio":
                    List<Models.Ingredients> ingredients2 = ingredientsrepo.FindBySubsidiaryAndCategory(2, "Emboltorio");

                    ingredients2.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));

                    string[] ingredientsnames2 = new string[ingredients2.Count];

                    // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
                    for (int i = 0; i < ingredients2.Count; i++)
                    {
                        ingredientsnames2[i] = ingredients2[i].Name;
                    }

                    ingredients_cbb.DataSource = ingredientsnames2;
                    break;
                case "Stickers":
                    List<Models.Ingredients> ingredients3 = ingredientsrepo.FindBySubsidiaryAndCategory(2, "Stickers");

                    ingredients3.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));

                    string[] ingredientsnames3 = new string[ingredients3.Count];

                    // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
                    for (int i = 0; i < ingredients3.Count; i++)
                    {
                        ingredientsnames3[i] = ingredients3[i].Name;
                    }

                    ingredients_cbb.DataSource = ingredientsnames3;
                    break;
                case "Ingredientes":
                    List<Models.Ingredients> ingredients4 = ingredientsrepo.FindBySubsidiaryAndCategory(2, "Ingredientes");

                    ingredients4.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));

                    string[] ingredientsnames4 = new string[ingredients4.Count];

                    // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
                    for (int i = 0; i < ingredients4.Count; i++)
                    {
                        ingredientsnames4[i] = ingredients4[i].Name;
                    }

                    ingredients_cbb.DataSource = ingredientsnames4;
                    break;
                default: break;
            }
        }
    }
}
