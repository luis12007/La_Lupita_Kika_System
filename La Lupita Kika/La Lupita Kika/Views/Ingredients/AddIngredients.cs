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
        private string category = "Emboltorio";
        private string productName;
        private float Number;
        private int subsidiaryint;
        private string type;
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
            productName = ingredients_cbb.SelectedItem.ToString();
            switch (category)
            {
                case "Fruta":
                    switch (productName)
                    {
                        case "Fresa":
                            Tipo.Text = "LIBRA";
                            break;
                        case "Mango maduro":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Mango verde":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Piña para fresco":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Arrayán":
                            Tipo.Text = "LIBRA";
                            //hacer conversion pertinente de unidad a libra (check)
                            break;
                        case "Tamarindo":
                            Tipo.Text = "LIBRA";
                            break;
                        case "Sandía grande":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Coco Sazón":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Mora":
                            Tipo.Text = "LIBRA";
                            break;
                        case "Jocote":
                            Tipo.Text = "CIENTO";
                            break;
                        case "Zapote":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Limón":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Naranja":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Kiwi":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Pepino":
                            Tipo.Text = "LIBRA";
                            break;
                        case "Hierba buena":
                            Tipo.Text = "HOJAS";
                            break;
                        case "Jamaica":
                            Tipo.Text = "LIBRA";
                            break;
                        case "Aguacate":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Acido cítrico":
                            Tipo.Text = "GRAMOS";
                            break;
                        case "Estabilizador paleta de agua":
                            Tipo.Text = "GRAMOS";
                            break;
                        default:
                            // Código para manejar otros casos no especificados (check)
                            break;
                    }


                    break;
                case "Emboltorio":
                    switch (productName)
                    {
                        case "Paleta madera":
                        case "Emboltorio paleta":
                        case "Palo para pincho":
                        case "Palo de madera":
                        case "Vaso mangoneada":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Servilleta":
                            Tipo.Text = "PAQUETES";
                            //hacer conversion
                            break;
                        default:
                            // Código para manejar otros casos no especificados (check)
                            break;
                    }
                    break;
                case "Stickers":
                    Tipo.Text = "UNIDAD";
                    break;
                case "Ingredientes":
                    switch (productName)
                    {
                        case "Acido cítrico":
                            Tipo.Text = "GRAMOS";
                            break;
                        case "Estabilizador paleta de agua":
                            Tipo.Text = "GRAMOS";
                            break;
                        case "Galleta oreo":
                            Tipo.Text = "PAQUETES";
                            break;
                        case "Leche entera":
                            Tipo.Text = "GALÓN";
                            break;
                        case "Vainilla":
                        case "Escencia de coco":
                            Tipo.Text = "LIBRA";
                            //de tbsp a libra
                            break;
                        case "Azucar":
                        case "Cebada":
                            Tipo.Text = "TAZA";
                            break;
                        case "Queso crema 230 gramos":
                        case "Leche condensada 395 gramos":
                        case "Café listo 2 gramos":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Chocolate liquido":
                            Tipo.Text = "ONZ";
                            break;
                        case "Horchata de maní":
                            Tipo.Text = "LIBRA";
                            break;
                        case "Estabilizador paleta de leche":
                            Tipo.Text = "GRAMOS";
                            break;
                        case "Tajín":
                            Tipo.Text = "TAZA";
                            break;
                        case "Sal":
                            Tipo.Text = "LIBRA";
                            //tbs a libra
                            break;
                        case "Alguashte":
                            //hacer cambios pertinentes de tbs a libra
                            Tipo.Text = "LIBRAS";
                            break;

                        case "Chile liquido":
                            //hacer cambios pertinentes de tbs a Galon
                            Tipo.Text = "GALON";
                            break;
                        case "Tequila":
                            Tipo.Text = "GRAMOS";
                            break;
                        case "Cerveza":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Salsa inglesa":
                            Tipo.Text = "LIBRA";
                            //de tbsp a libra
                            break;
                        case "Jugo de tomate":
                            Tipo.Text = "TAZA";
                            break;
                        case "Soda mineral de limón":
                            Tipo.Text = "UNIDAD";
                            break;
                        case "Ron claro":
                            Tipo.Text = "TAZA";
                            break;
                        case "Maizena":
                            Tipo.Text = "LIBRA";
                            //de tbsp a libra
                            break;
                        default:
                            // Código para manejar otros casos no especificados
                            break;
                    }

                    break;
                default: break;
            }
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
            Products_dataGridView.Columns["Nombre"].Width = 251;
            Products_dataGridView.Columns["Cidigo"].Width = 117;
            Products_dataGridView.Columns["Diferencia"].Width = 157;
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
            Number = float.Parse(Number_textbox.Texts);
            subsidiary = Subsidiary_cbb.SelectedItem.ToString();
            subsidiaryint = subsidiaryrepo.FindIdByName(subsidiary);
            type = Tipo.Text;


            switch (Ingredient)
            {

                case "Alguashte":
                    Number = Number / 0.0326f;
                    break;

                case "Chile liquido":
                    Number = Number / 0.003906f;
                    break;

                case "Arrayán":
                    Number = Number * 6f;
                    break;

                case "Servilleta":
                    Number = Number * 40f;
                    break;
                case "Vainilla":
                    Number = Number / 0.0326f;
                    break;
                case "Escencia de coco":
                    Number = Number / 0.0326f;
                    break;
                case "Sal":
                    Number = Number / 0.0326f;
                    break;
                case "Salsa inglesa":
                    Number = Number / 0.0326f;
                    break;
                case "Maizena":
                    Number = Number / 0.0326f;
                    break;
                case "Acido cítrico":
                    Number = Number / 0.0022f;
                    break;
                case "Estabilizador paleta de agua":
                    Number = Number / 0.0022f;
                    break;
                default: break;
            }

            //

            //

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
                Models.Products productpalette = new Models.Products(addingredient.Name, (addingredient.Unit + Number), addingredient.Price, "Paletas", addingredient.Code, addingredient.Unit, Number, addingredient.Subsidiary_ID, addingredient.Type);
                productosList.Add(productpalette);
            }

            Products_dataGridView.Rows.Clear();


            string typeingredient = "none";
            float cuantitydbchange, Numberaddchange = 0;
            foreach (var palettec in productosList)
            {
                typeingredient = palettec.catego;
                cuantitydbchange = palettec.Cuantitydb;
                Numberaddchange = palettec.Numberadd;
                switch (palettec.Nombre)
                {

                    case "Alguashte":
                        cuantitydbchange = cuantitydbchange * 0.0326f;
                        Numberaddchange = Numberaddchange * 0.0326f;
                        typeingredient = "LIBRA";
                        break;

                    case "Chile liquido":
                        typeingredient = "GALON";
                        cuantitydbchange = cuantitydbchange * 0.003906f;
                        Numberaddchange = Numberaddchange * 0.003906f;
                        break;

                    case "Arrayán":
                        typeingredient = "LIBRA";
                        cuantitydbchange = cuantitydbchange / 6f;
                        Numberaddchange = Numberaddchange / 6f;
                        break;

                    case "Servilleta":
                        typeingredient = "PAQUETES";
                        cuantitydbchange = cuantitydbchange / 40f;
                        Numberaddchange = Numberaddchange / 40f;
                        break;
                    default: break;
                }

                switch (typeingredient)
                {

                    case "TBSP":
                        cuantitydbchange = cuantitydbchange * 0.0326f;
                        Numberaddchange = Numberaddchange * 0.0326f;
                        typeingredient = "LIBRA";
                        break;

                    case "TBS":
                        cuantitydbchange = cuantitydbchange * 0.0326f;
                        Numberaddchange = Numberaddchange * 0.0326f;
                        typeingredient = "LIBRA";
                        break;

                    /*case "GRAMOS":
                        cuantitydbchange = cuantitydbchange * 0.0022f;
                        Numberaddchange = Numberaddchange * 0.0022f;
                        typeingredient = "LIBRA";
                        break;*/

                    default: break;
                }

                // Redondear el número a dos decimales
                float roundedNumberdb = (float)Math.Round(cuantitydbchange, 2);

                // Si el número redondeado es 0.00, mostrar un decimal más
                if (roundedNumberdb == 0.00f)
                {
                    roundedNumberdb = (float)Math.Round(cuantitydbchange, 4);
                }

                // Crear un nuevo String[] con los valores de cada elemento en la lista
                String[] row2 = { palettec.Nombre, palettec.Codebar,
                            $"{roundedNumberdb} -> {roundedNumberdb + Numberaddchange}", $"{typeingredient}",$"{subsidiaryrepo.FindNameById(palettec.Subsidiary_id)}"  };

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

        private void Products_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
