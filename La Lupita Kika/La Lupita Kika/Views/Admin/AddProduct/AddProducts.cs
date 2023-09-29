using Google.Protobuf.WellKnownTypes;
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

namespace La_Lupita_Kika.Views.Admin.AddProduct
{
    public partial class AddProducts : Form
    {
        private string ConnectionString;
        private string type;
        private string category;
        private string productName;
        private int Number;
        private string Codebar;

        private List<Models.Products> productosList = new List<Models.Products>(); // Lista de productos
        private List<Models.Products> productosFaltantesList = new List<Models.Products>(); // Lista de productos que faltan
        private List<string> clearlist = new List<string>();


        private UserRepository.PalettesRepository palettesrepo;
        private SnowIceRepository snowicerepo;
        private MangoneadasRepository mangoneadasrepo;
        private CandyRepository candysrepo;
        private OtherRepository otherrepo;
        private CategoryRepository categoryrepo;
        private CategoryCRepository categoryCrepo;
        private SubsidiaryRepository subsidiaryrepo;
        private IngredientsRepository ingredientsrepo;
        private string subsidiary;
        private int subsidiaryint;
        public AddProducts(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.palettesrepo = new UserRepository.PalettesRepository(connectionString);
            this.snowicerepo = new SnowIceRepository(connectionString);
            this.mangoneadasrepo = new MangoneadasRepository(connectionString);
            this.candysrepo = new CandyRepository(connectionString);
            this.otherrepo = new OtherRepository(connectionString);
            this.categoryrepo = new CategoryRepository(connectionString);
            this.categoryCrepo = new CategoryCRepository(connectionString);
            this.subsidiaryrepo = new SubsidiaryRepository(connectionString);
            this.ingredientsrepo = new IngredientsRepository(connectionString);
            InitializeComponent();
            InitializeDataGridView();
            this.FormClosing += MainForm_FormClosing;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que quieres cerrar la aplicación?", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Si el usuario hace clic en "No", cancela el evento de cierre.
                e.Cancel = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddProducts_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home formFacturation = new Home(ConnectionString);
            formFacturation.ShowDialog();
        }

        private void Products_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            type = Products_cbb.SelectedItem.ToString();
            subsidiary = Subsidiary_cbb.SelectedItem.ToString();
            switch (type)
            {
                case "Paletas":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    //view changes--------------------------------------------------------
                    Name_cbb.Visible = true;
                    Name_cbb.Enabled = true;
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    name_label.Location = new Point(name_label.Location.X, 250);
                    Name_cbb.Location = new Point(Name_cbb.Location.X, 280);
                    Number_label.Location = new Point(Number_label.Location.X, 330);
                    Number_textbox.Location = new Point(Number_textbox.Location.X, 360);
                    //view changes--------------------------------------------------------

                    List<Category> categoriesList = categoryrepo.GetAll();

                    string[] categoryNames = new string[categoriesList.Count];

                    // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
                    for (int i = 0; i < categoriesList.Count; i++)
                    {
                        categoryNames[i] = categoriesList[i].Name;
                    }

                    Category_cbb.DataSource = categoryNames;
                    Category_cbb.DisplayMember = "Seleccionar";


                    break;

                case "Mangoneadas":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    //view changes--------------------------------------------------------

                    Name_cbb.Visible = true;
                    Name_cbb.Enabled = true;
                    Category_cbb.Visible = false;
                    Cat_label.Visible = false;
                    Number_label.Visible = true;
                    Number_textbox.Visible = true;
                    Number_label.Enabled = true;
                    Number_textbox.Enabled = true;
                    name_label.Location = new Point(name_label.Location.X, 160);
                    Name_cbb.Location = new Point(Name_cbb.Location.X, 200);
                    Number_label.Location = new Point(Number_label.Location.X, 250);
                    Number_textbox.Location = new Point(Number_textbox.Location.X, 280);
                    //view changes-------------------------------------------------------
                    Name_cbb.DataSource = clearlist;
                    Category_cbb.DataSource = clearlist;
                    subsidiary = Subsidiary_cbb.SelectedItem.ToString();
                    subsidiaryint = subsidiaryrepo.FindIdByName(subsidiary);

                    List<string> namesmango = mangoneadasrepo.GetAllNamesBySubsidiaryId(subsidiaryint);
                    Name_cbb.DataSource = namesmango;

                    break;

                case "Helados":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    Name_cbb.DataSource = clearlist;
                    Category_cbb.DataSource = clearlist;
                    //view changes--------------------------------------------------------
                    Name_cbb.Visible = true;
                    Name_cbb.Enabled = true;

                    Category_cbb.Visible = false;
                    Cat_label.Visible = false;

                    name_label.Location = new Point(name_label.Location.X, 160);
                    Name_cbb.Location = new Point(Name_cbb.Location.X, 190);
                    Number_label.Location = new Point(Number_label.Location.X, 240);
                    Number_textbox.Location = new Point(Number_textbox.Location.X, 270);
                    //view changes--------------------------------------------------------
                    subsidiary = Subsidiary_cbb.SelectedItem.ToString();
                    subsidiaryint = subsidiaryrepo.FindIdByName(subsidiary);
                    List<string> namesnow = snowicerepo.GetAllProductNamesBySubsidiaryId(subsidiaryint);
                    Name_cbb.DataSource = namesnow;

                    break;

                case "Dulces":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    Name_cbb.DataSource = clearlist;
                    Category_cbb.DataSource = clearlist;
                    //view changes--------------------------------------------------------

                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    Name_cbb.Visible = true;
                    Name_cbb.Enabled = true;
                    name_label.Visible = true;
                    name_label.Enabled = true;
                    //Barcode_textbox.Location = new Point(Barcode_textbox.Location.X, 490);
                    //Codebar_label.Location = new Point(Codebar_label.Location.X, 450);
                    name_label.Location = new Point(name_label.Location.X, 250);
                    Name_cbb.Location = new Point(Name_cbb.Location.X, 280);
                    Number_label.Location = new Point(Number_label.Location.X, 330);
                    Number_textbox.Location = new Point(Number_textbox.Location.X, 360);
                    Number_label.Visible = true;
                    Number_label.Enabled = true;
                    Number_textbox.Visible = true;
                    Number_textbox.Enabled = true;

                    //view changes--------------------------------------------------------

                    List<CategoryC> categoriesCList = categoryCrepo.GetAll();

                    string[] categoryCNames = new string[categoriesCList.Count];

                    // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
                    for (int i = 0; i < categoriesCList.Count; i++)
                    {
                        categoryCNames[i] = categoriesCList[i].Name;
                    }

                    Category_cbb.DataSource = categoryCNames;
                    Category_cbb.DisplayMember = "Seleccionar";

                    break;

                case "Otros(snacks)":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    Name_cbb.DataSource = clearlist;
                    Category_cbb.DataSource = clearlist;
                    //view changes--------------------------------------------------------
                    Name_cbb.Visible = true;
                    Name_cbb.Enabled = true;
                    Category_cbb.Visible = false;
                    Cat_label.Visible = false;
                    //Barcode_textbox.Location = new Point(Barcode_textbox.Location.X, 490);
                    //Codebar_label.Location = new Point(Codebar_label.Location.X, 450);
                    name_label.Location = new Point(name_label.Location.X, 160);
                    Name_cbb.Location = new Point(Name_cbb.Location.X, 190);
                    Number_label.Location = new Point(Number_label.Location.X, 240);
                    Number_textbox.Location = new Point(Number_textbox.Location.X, 270);


                    //view changes--------------------------------------------------------

                    subsidiary = Subsidiary_cbb.SelectedItem.ToString();
                    subsidiaryint = subsidiaryrepo.FindIdByName(subsidiary);

                    List<string> namesother = otherrepo.GetAllNamesBySubsidiaryId(subsidiaryint);
                    Name_cbb.DataSource = namesother;
                    break;

                default:
                    //view changes--------------------------------------------------------
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;

                    //view changes--------------------------------------------------------
                    break;
            }
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Number_textbox.Texts, out int result))
            {
                MessageBox.Show("Valor ingresado en cantidad no es un numero.", "Cuidado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Number_textbox.Texts = "";
                return;
            }


            type = Products_cbb.SelectedItem.ToString();
            Number = int.Parse(Number_textbox.Texts);
            subsidiary = Subsidiary_cbb.SelectedItem.ToString();
            subsidiaryint = subsidiaryrepo.FindIdByName(subsidiary);
            switch (type)
            {
                case "Paletas":
                    //view changes--------------------------------------------------------

                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    //view changes--------------------------------------------------------
                    category = Category_cbb.SelectedItem.ToString();
                    Number = int.Parse(Number_textbox.Texts);

                    productName = Name_cbb.SelectedItem.ToString();

                    Palettes palette = palettesrepo.FindProductByNameAndSubsidiary(productName, subsidiaryint);
                    if (palette == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductMango = productosList.FirstOrDefault(p =>
                        p.Nombre == palette.Name && p.Valor == palette.Price && p.Tipo == "Paletas" && p.Subsidiary_id == palette.Subsidiary_ID);

                    if (existingProductMango != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductMango.Cantidad += Number;
                        existingProductMango.Numberadd += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista

                        Models.Products productpalette = new Models.Products(palette.Name, Number, palette.Price, "Paletas", palette.Codebar, palette.Cuantity, Number, palette.Subsidiary_ID);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar,
                            $"{palettec.Cuantitydb} -> {palettec.Cuantitydb + palettec.Numberadd}",$"{subsidiaryrepo.FindNameById(palettec.Subsidiary_id)}"  };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    Number_textbox.Texts = "";
                    break;

                case "Mangoneadas":
                    //view changes--------------------------------------------------------

                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    //view changes-------------------------------------------------------
                    productName = Name_cbb.SelectedItem.ToString();
                    Number = int.Parse(Number_textbox.Texts);
                    Mangoneadas mango = mangoneadasrepo.FindByProductNameAndSubsidiary(productName, subsidiaryint);
                    if (mango == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductpalette = productosList.FirstOrDefault(p =>
                        p.Nombre == mango.Name && p.Valor == mango.Price && p.Tipo == "Mangoneada" && p.Subsidiary_id == mango.Subsidiary_ID);

                    if (existingProductpalette != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductpalette.Cantidad += Number;
                        existingProductpalette.Numberadd += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(mango.Name, Number, mango.Price, "Mangoneada", mango.Codebar, mango.Cuantity, Number, mango.Subsidiary_ID);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar,
                            $"{palettec.Cuantitydb} -> {palettec.Cuantitydb + palettec.Numberadd}",$"{subsidiaryrepo.FindNameById(palettec.Subsidiary_id)}" };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }

                    Number_textbox.Texts = "";
                    break;

                case "Helados":

                    productName = Name_cbb.SelectedItem.ToString();
                    Number = int.Parse(Number_textbox.Texts);
                    SnowIce helado = snowicerepo.FindSnowIceByNameAndSubsidiary(productName, subsidiaryint);
                    if (helado == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductsnow = productosList.FirstOrDefault(p =>
                        p.Nombre == helado.Name && p.Valor == helado.Price && p.Tipo == "Helados" && p.Subsidiary_id == helado.Subsidiary_ID);

                    if (existingProductsnow != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductsnow.Cantidad += Number;
                        existingProductsnow.Numberadd += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(helado.Name, Number, helado.Price, "Helados", helado.Codebar, helado.Cuantity, Number, helado.Subsidiary_ID);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar,
                            $"{palettec.Cuantitydb} -> {palettec.Cuantitydb + palettec.Numberadd}" , $"{subsidiaryrepo.FindNameById(palettec.Subsidiary_id)}"};

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    Number_textbox.Texts = "";
                    break;

                case "Dulces":

                    productName = Name_cbb.SelectedItem.ToString();
                    Candy dulce = candysrepo.FindCandyByNameAndSubsidiary(productName, subsidiaryint);
                    if (dulce == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductcandy = productosList.FirstOrDefault(p =>
                        p.Nombre == dulce.Name && p.Valor == dulce.Price && p.Tipo == "Dulces" && dulce.Codebar == p.Codebar && p.Subsidiary_id == dulce.Subsidiary_ID);

                    if (existingProductcandy != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductcandy.Cantidad += Number;
                        existingProductcandy.Numberadd += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(dulce.Name, Number, dulce.Price, "Dulces", dulce.Codebar, dulce.Cuantity, Number, dulce.Subsidiary_ID);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar,
                            $"{palettec.Cuantitydb} -> {palettec.Cuantitydb + palettec.Numberadd}",$"{subsidiaryrepo.FindNameById(palettec.Subsidiary_id)}" };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    Number_textbox.Texts = "";
                    break;

                case "Otros(snacks)":

                    productName = Name_cbb.SelectedItem.ToString();
                    Other other = otherrepo.FindOtherByNameAndSubsidiary(productName, subsidiaryint);
                    if (other == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductOtros = productosList.FirstOrDefault(p =>
                        p.Nombre == other.Name && p.Valor == other.Price && p.Tipo == "Otros(snacks)" && other.Codebar == p.Codebar && p.Subsidiary_id == other.Subsidiary_ID);

                    if (existingProductOtros != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductOtros.Cantidad += Number;
                        existingProductOtros.Numberadd += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(other.Name, Number, other.Price, "Otros(snacks)", other.Codebar, other.Cuantity, Number, other.Subsidiary_ID);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar, $"{palettec.Cuantitydb} -> {palettec.Cuantitydb + palettec.Numberadd}",
                        $"{subsidiaryrepo.FindNameById(palettec.Subsidiary_id)}"};

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    Number_textbox.Texts = "";
                    break;

                default:

                    break;
            }
        }

        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            Products_dataGridView.ColumnCount = 6;      // Columna para el nombre del producto
            Products_dataGridView.Columns[0].Name = "Nombre";
            Products_dataGridView.Columns[1].Name = "Cantidad";
            Products_dataGridView.Columns[2].Name = "Tipo";
            Products_dataGridView.Columns[3].Name = "Barcode";
            Products_dataGridView.Columns[4].Name = "Diferencia";
            Products_dataGridView.Columns[5].Name = "Sucursal";



            // Ajustar el ancho de las columnas
            Products_dataGridView.Columns["Nombre"].Width = 277;
            Products_dataGridView.Columns["Cantidad"].Width = 100;
            Products_dataGridView.Columns["tipo"].Width = 110;
            Products_dataGridView.Columns["barcode"].Width = 127;
            Products_dataGridView.Columns["Cantidad"].Width = 127;
            Products_dataGridView.Columns["Sucursal"].Width = 120;

        }

        private void Category_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            type = Products_cbb.SelectedItem.ToString();

            switch (type)
            {
                case "Paletas":
                    //view changes--------------------------------------------------------

                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    //view changes--------------------------------------------------------
                    category = Category_cbb.SelectedItem.ToString();
                    subsidiary = Subsidiary_cbb.SelectedItem.ToString();
                    subsidiaryint = subsidiaryrepo.FindIdByName(subsidiary);
                    switch (category)
                    {
                        case "cremosas":
                            Name_cbb.DataSource = palettesrepo.GetNamesByCategoryIdAndSubsidiaryId(1, subsidiaryint);
                            break;
                        case "picantes":
                            Name_cbb.DataSource = palettesrepo.GetNamesByCategoryIdAndSubsidiaryId(2, subsidiaryint);
                            break;
                        case "fruta":
                            Name_cbb.DataSource = palettesrepo.GetNamesByCategoryIdAndSubsidiaryId(3, subsidiaryint);
                            break;
                        case "licor":
                            Name_cbb.DataSource = palettesrepo.GetNamesByCategoryIdAndSubsidiaryId(4, subsidiaryint);
                            break;
                        default:
                            // Acción por defecto si no coincide con ninguna categoría
                            break;
                    }


                    break;

                case "Helados":
                    //view changes--------------------------------------------------------

                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;

                    break;

                case "Dulces":
                    //view changes--------------------------------------------------------

                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;

                    //view changes--------------------------------------------------------


                    category = Category_cbb.SelectedItem.ToString();
                    subsidiary = Subsidiary_cbb.SelectedItem.ToString();
                    subsidiaryint = subsidiaryrepo.FindIdByName(subsidiary);
                    switch (category)
                    {
                        case "mejicanos":
                            Name_cbb.DataSource = candysrepo.FindNamesByCategoryAndSubsidiary(1, subsidiaryint);
                            break;
                        case "choco-banano":
                            Name_cbb.DataSource = candysrepo.FindNamesByCategoryAndSubsidiary(2, subsidiaryint);
                            break;
                        case "otros":
                            Name_cbb.DataSource = candysrepo.FindNamesByCategoryAndSubsidiary(3, subsidiaryint);
                            break;
                        default:
                            // Acción por defecto si no coincide con ninguna categoría
                            break;
                    }
                    break;

                case "Otros(snacks)":
                    //view changes--------------------------------------------------------

                    Category_cbb.Visible = false;
                    Cat_label.Visible = false;
                    //view changes--------------------------------------------------------

                    break;

                default:
                    //view changes--------------------------------------------------------
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;

                    //view changes--------------------------------------------------------
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
                // Obtén la categoría del producto actual
                string tipoProducto = producto.Tipo;

                // Realiza acciones dependiendo de la categoría del producto
                switch (tipoProducto)
                {
                    case "Paletas":
                        palettesrepo.UpdateCuantityByCodebarAndSubsidiary(producto.Codebar, producto.Cantidad, producto.Subsidiary_id);
                        break;
                    case "Helados":
                        snowicerepo.IncrementCuantityByCodebarPlus(producto.Codebar, producto.Cantidad, producto.Subsidiary_id);
                        break;
                    case "Mangoneada":
                        mangoneadasrepo.UpdateCuantityByCodebarPlus(producto.Codebar, producto.Cantidad, producto.Subsidiary_id);
                        break;
                    case "Dulces":
                        candysrepo.UpdateCuantityByCodebarPlus(producto.Codebar, producto.Cantidad, producto.Subsidiary_id);
                        break;
                    case "Otros(snacks)":
                        otherrepo.UpdateCuantityByCodebarPlus(producto.Codebar, producto.Cantidad, producto.Subsidiary_id);
                        break;
                    default:
                        MessageBox.Show("Error contacte a soporte");
                        break;
                }
            }
            productosFaltantesList.Clear();
            //ingredients
            CalculateIngredients();

            if (productosFaltantesList.Count > 0)
            {
                this.Hide();

                Warning warning = new Warning(ConnectionString, productosFaltantesList, "Productos que hacen falta");
                warning.ShowDialog();

                this.Show();
            }

            MessageBox.Show("Agreagdo correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Products_dataGridView.Rows.Clear();
            Products_dataGridView.Refresh();
            productosFaltantesList.Clear();
            productosList.Clear();

        }

        private void add_manual_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Abrir el nuevo formulario de facturación
            AddManual formFacturation = new AddProduct.AddManual(ConnectionString);
            formFacturation.ShowDialog();

            this.Show();
        }

        private void Subsidiary_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Subsidiary_cbb_Click(object sender, EventArgs e)
        {
            Products_cbb_OnSelectedIndexChanged(sender, e);
        }

        private void CalculateIngredients()
        {
            // recorriendo para ingredientes
            foreach (var producto in productosList)
            {
                switch (producto.Codebar.ToUpper())
                {
                    case "M03":
                        Dictionary<string, float> ingredientsToSubtractm03 = new Dictionary<string, float>
                                {
                                    { "Jocote", 2.86f * producto.Cantidad },
                                    { "Azucar", 0.09f * producto.Cantidad },
                                    { "Sal", 0.06f * producto.Cantidad },
                                    { "Acido cítrico", 0.20f * producto.Cantidad },
                                    { "Maizena", 0.06f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker jocote", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm03)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType,$"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M04":
                        Dictionary<string, float> ingredientsToSubtractm04 = new Dictionary<string, float>
                                {
                                    { "Arrayán", 0.20f * producto.Cantidad },
                                    { "Azucar", 0.11f * producto.Cantidad },
                                    { "Sal", 0.06f * producto.Cantidad },
                                    { "Acido cítrico", 0.20f * producto.Cantidad },
                                    { "Maizena", 0.06f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker arrayán", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm04)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M05":
                        Dictionary<string, float> ingredientsToSubtractm05 = new Dictionary<string, float>
                                {
                                    { "Mora", 0.10f * producto.Cantidad },
                                    { "Azucar", 0.10f * producto.Cantidad },
                                    { "Acido cítrico", 0.23f * producto.Cantidad },
                                    { "Maizena", 0.07f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker mora", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm05)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M06":
                        Dictionary<string, float> ingredientsToSubtractm06 = new Dictionary<string, float>
                                {
                                    { "Mango maduro", 0.53f * producto.Cantidad },
                                    { "Azucar", 0.10f * producto.Cantidad },
                                    { "Sal", 0.07f * producto.Cantidad },
                                    { "Acido cítrico", 0.23f * producto.Cantidad },
                                    { "Maizena", 0.07f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker mango maduro", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm06)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M07":
                        Dictionary<string, float> ingredientsToSubtractm07 = new Dictionary<string, float>
                                {
                                    { "Mango verde", 0.53f * producto.Cantidad },
                                    { "Azucar", 0.12f * producto.Cantidad },
                                    { "Sal", 0.07f * producto.Cantidad },
                                    { "Acido cítrico", 0.23f * producto.Cantidad },
                                    { "Maizena", 0.07f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker mango verde", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm07)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );
                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M08":
                        Dictionary<string, float> ingredientsToSubtractm08 = new Dictionary<string, float>
                                {
                                    { "Piña para fresco", 0.05f * producto.Cantidad },
                                    { "Azucar", 0.15f * producto.Cantidad },
                                    { "Sal", 0.10f * producto.Cantidad },
                                    { "Acido cítrico", 0.35f * producto.Cantidad },
                                    { "Maizena", 0.10f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker piña", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm08)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M09":
                        Dictionary<string, float> ingredientsToSubtractm09 = new Dictionary<string, float>
                                {
                                    { "Fresa", 0.08f * producto.Cantidad },
                                    { "Azucar", 0.10f * producto.Cantidad },
                                    { "Sal", 0.03f * producto.Cantidad },
                                    { "Acido cítrico", 0.23f * producto.Cantidad },
                                    { "Maizena", 0.07f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker fresa", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm09)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M10":
                        Dictionary<string, float> ingredientsToSubtractm10 = new Dictionary<string, float>
                                {
                                    { "Tamarindo", 0.05f * producto.Cantidad },
                                    { "Azucar", 0.18f * producto.Cantidad },
                                    { "Sal", 0.10f * producto.Cantidad },
                                    { "Acido cítrico", 0.35f * producto.Cantidad },
                                    { "Maizena", 0.10f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker tamarindo", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm10)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M11":
                        Dictionary<string, float> ingredientsToSubtractm11 = new Dictionary<string, float>
                                    {
                                        { "Sandía grande", 0.03f * producto.Cantidad },
                                        { "Azucar", 0.07f * producto.Cantidad },
                                        { "Acido cítrico", 0.23f * producto.Cantidad },
                                        { "Maizena", 0.07f * producto.Cantidad },
                                        { "Palo de madera", 1.00f * producto.Cantidad },
                                        { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                        { "Sticker sandía", 1.00f * producto.Cantidad }
                                    };

                        foreach (var ingredientEntry in ingredientsToSubtractm11)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "M01":
                        Dictionary<string, float> ingredientsToSubtractm01 = new Dictionary<string, float>
                                {
                                    { "Tamarindo", 0.03f * producto.Cantidad },
                                    { "Azucar", 0.10f * producto.Cantidad },
                                    { "Cerveza", 0.13f * producto.Cantidad },
                                    { "Jugo de tomate", 0.03f * producto.Cantidad },
                                    { "Salsa inglesa", 0.07f * producto.Cantidad },
                                    { "Sal", 0.07f * producto.Cantidad },
                                    { "Limón", 0.07f * producto.Cantidad },
                                    { "Tajín", 0.02f * producto.Cantidad },
                                    { "Chile liquido", 0.07f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker michelada", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm01)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }



                        break;
                    case "M02":
                        Dictionary<string, float> ingredientsToSubtractm02 = new Dictionary<string, float>
                                {
                                    { "Piña para fresco", 0.03f * producto.Cantidad },
                                    { "Azucar", 0.10f * producto.Cantidad },
                                    { "Cerveza", 0.13f * producto.Cantidad },
                                    { "Jugo de tomate", 0.03f * producto.Cantidad },
                                    { "Salsa inglesa", 0.07f * producto.Cantidad },
                                    { "Sal", 0.07f * producto.Cantidad },
                                    { "Limón", 0.07f * producto.Cantidad },
                                    { "Tajín", 0.02f * producto.Cantidad },
                                    { "Chile liquido", 0.07f * producto.Cantidad },
                                    { "Palo de madera", 1.00f * producto.Cantidad },
                                    { "Vaso mangoneada", 1.00f * producto.Cantidad },
                                    { "Sticker michelanga", 1.00f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractm02)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }


                        break;

                    case "C01":
                        Dictionary<string, float> ingredientsToSubtract = new Dictionary<string, float>
                            {
                            { "Galleta oreo", 0.075f * producto.Cantidad },
                            { "Leche entera", 0.01f* producto.Cantidad },
                            { "Vainilla", 0.05f * producto.Cantidad },
                            { "Azucar", 0.075f* producto.Cantidad },
                            { "Queso crema 230 gramos", 0.025f* producto.Cantidad },
                            { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                            { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                            { "Paleta madera", 1f * producto.Cantidad },
                            { "Emboltorio paleta", 1f * producto.Cantidad },
                            { "Servilleta", 1f * producto.Cantidad },
                            { "Sticker la luna", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtract)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }


                        break;
                    case "C02":
                        Dictionary<string, float> ingredientsToSubtractc02 = new Dictionary<string, float>
                            {
                                { "Coco sazón", 0.075f * producto.Cantidad },
                                { "Leche entera", 0.01f * producto.Cantidad },
                                { "Escencia de coco", 0.05f * producto.Cantidad },
                                { "Azucar", 0.0625f * producto.Cantidad },
                                { "Queso crema 230 gramos", 0.025f * producto.Cantidad },
                                { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                                { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker la palma", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractc02)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }


                        break;
                    case "C03":
                        Dictionary<string, float> ingredientsToSubtractc03 = new Dictionary<string, float>
                            {
                                { "Café listo 2 gramos", 0.075f * producto.Cantidad },
                                { "Leche entera", 0.01f * producto.Cantidad },
                                { "Vainilla", 0.05f * producto.Cantidad },
                                { "Azucar", 0.0625f * producto.Cantidad },
                                { "Queso crema 230 gramos", 0.025f * producto.Cantidad },
                                { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                                { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f* producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker el apache", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractc03)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "C04":
                        Dictionary<string, float> ingredientsToSubtractc04 = new Dictionary<string, float>
                            {
                                { "Chocolate liquido", 0.125f * producto.Cantidad },
                                { "Leche entera", 0.01f * producto.Cantidad },
                                { "Vainilla", 0.05f * producto.Cantidad },
                                { "Azucar", 0.0625f * producto.Cantidad },
                                { "Queso crema 230 gramos", 0.025f * producto.Cantidad },
                                { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                                { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker el negrito", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractc04)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }


                        break;
                    case "C05":
                        Dictionary<string, float> ingredientsToSubtractc05 = new Dictionary<string, float>
                            {
                                { "Zapote", 0.075f * producto.Cantidad },
                                { "Leche entera", 0.01f * producto.Cantidad },
                                { "Vainilla", 0.025f * producto.Cantidad },
                                { "Azucar", 0.0625f * producto.Cantidad },
                                { "Queso crema 230 gramos", 0.025f * producto.Cantidad },
                                { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                                { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker el catrín", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractc05)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        //
                        break;
                    case "C06":
                        Dictionary<string, float> ingredientsToSubtractc06 = new Dictionary<string, float>
                            {
                                { "Fresa", 0.0375f * producto.Cantidad },
                                { "Leche entera", 0.01f * producto.Cantidad },
                                { "Vainilla", 0.025f * producto.Cantidad },
                                { "Azucar", 0.0625f * producto.Cantidad },
                                { "Queso crema 230 gramos", 0.025f * producto.Cantidad },
                                { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                                { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker el corazón", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractc06)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }


                        break;
                    case "C07":
                        Dictionary<string, float> ingredientsToSubtractc07 = new Dictionary<string, float>
                            {
                                { "Cebada", 0.0375f * producto.Cantidad },
                                { "Leche entera", 0.01f * producto.Cantidad },
                                { "Azucar", 0.0625f * producto.Cantidad },
                                { "Queso crema 230 gramos", 0.025f * producto.Cantidad },
                                { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                                { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 0.025f * producto.Cantidad },
                                { "Sticker la selena", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractc07)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "C08":
                        Dictionary<string, float> ingredientsToSubtractc08 = new Dictionary<string, float>
                            {
                                { "Horchata de maní", 0.0125f * producto.Cantidad },
                                { "Leche entera", 0.01f * producto.Cantidad },
                                { "Vainilla", 0.025f * producto.Cantidad },
                                { "Azucar", 0.0625f * producto.Cantidad },
                                { "Queso crema 230 gramos", 0.025f * producto.Cantidad },
                                { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                                { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker La estrella", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractc08)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "C09":
                        Dictionary<string, float> ingredientsToSubtractc09 = new Dictionary<string, float>
                            {
                                { "Aguacate", 0.05f * producto.Cantidad },
                                { "Leche entera", 0.01f * producto.Cantidad },
                                { "Vainilla", 0.025f * producto.Cantidad },
                                { "Azucar", 0.1125f * producto.Cantidad },
                                { "Queso crema 230 gramos", 0.025f * producto.Cantidad },
                                { "Leche condensada  395 gramos", 0.025f * producto.Cantidad },
                                { "Estabilizador paleta de leche", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker la rana", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractc09)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }
                        break;

                    case "P01":
                        Dictionary<string, float> ingredientsToSubtractp01 = new Dictionary<string, float>
                            {
                                { "Tamarindo", 0.025f * producto.Cantidad },
                                { "Azucar", 0.0875f * producto.Cantidad },
                                { "Tajín", 0.0125f * producto.Cantidad },
                                { "Sal", 0.05f * producto.Cantidad },
                                { "Acido cítrico", 0.175f * producto.Cantidad },
                                { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker el alacrán", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractp01)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "P02":
                        Dictionary<string, float> ingredientsToSubtractp02 = new Dictionary<string, float>
                                    {
                                        { "Piña para fresco", 0.0375f * producto.Cantidad },
                                        { "Azucar", 0.0875f * producto.Cantidad },
                                        { "Tajín", 0.0125f * producto.Cantidad },
                                        { "Sal", 0.05f * producto.Cantidad },
                                        { "Acido cítrico", 0.175f * producto.Cantidad },
                                        { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                        { "Paleta madera", 1f * producto.Cantidad },
                                        { "Emboltorio paleta", 1f * producto.Cantidad },
                                        { "Servilleta", 1f * producto.Cantidad },
                                        { "Sticker la sirena", 1f * producto.Cantidad }
                                    };

                        foreach (var ingredientEntry in ingredientsToSubtractp02)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "P03":
                        Dictionary<string, float> ingredientsToSubtractp03 = new Dictionary<string, float>
                            {
                                { "Mango verde", 0.3f * producto.Cantidad },
                                { "Azucar", 0.0875f * producto.Cantidad },
                                { "Tajín", 0.0125f * producto.Cantidad },
                                { "Sal", 0.05f * producto.Cantidad },
                                { "Acido cítrico", 0.175f * producto.Cantidad },
                                { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker el venado", 1f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractp03)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;

                    case "P04":
                        Dictionary<string, float> ingredientsToSubtractp04 = new Dictionary<string, float>
                            {
                                { "Arrayán", 0.175f * producto.Cantidad },
                                { "Azucar", 0.1125f * producto.Cantidad },
                                { "Tajín", 0.0125f * producto.Cantidad },
                                { "Sal", 0.05f * producto.Cantidad },
                                { "Acido cítrico", 0.175f * producto.Cantidad },
                                { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                { "Paleta madera", 1f * producto.Cantidad },
                                { "Emboltorio paleta", 1f * producto.Cantidad },
                                { "Servilleta", 1f * producto.Cantidad },
                                { "Sticker la garza", 1f * producto.Cantidad },
                                { "Alguashte", 0.05f * producto.Cantidad }
                            };

                        foreach (var ingredientEntry in ingredientsToSubtractp04)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "P05":
                        Dictionary<string, float> ingredientsToSubtractp05 = new Dictionary<string, float>
                                {
                                    { "Fresa", 0.0625f * producto.Cantidad },
                                    { "Azucar", 0.0875f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Sal", 0.05f * producto.Cantidad },
                                    { "Acido cítrico", 0.175f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                    { "Sticker la dama", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractp05)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "P06":
                        Dictionary<string, float> ingredientsToSubtractp06 = new Dictionary<string, float>
                                {
                                    { "Pepino", 0.0625f * producto.Cantidad },
                                    { "Limón", 0.15f * producto.Cantidad },
                                    { "Hierba buena", 0.175f * producto.Cantidad },
                                    { "Azucar", 0.075f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Sal", 0.05f * producto.Cantidad },
                                    { "Acido cítrico", 0.175f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                                            {"Sticker el nopal", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractp06)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "P07":
                        Dictionary<string, float> ingredientsToSubtractp07 = new Dictionary<string, float>
                                {
                                    { "Sandía grande", 0.025f * producto.Cantidad },
                                    { "Kiwi", 0.075f * producto.Cantidad },
                                    { "Azucar", 0.05f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Chile liquido", 0.05f * producto.Cantidad },
                                    { "Acido cítrico", 0.175f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                    {"Sticker la sandía", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractp07)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "P08":
                        Dictionary<string, float> ingredientsToSubtractp08 = new Dictionary<string, float>
                                {
                                    { "Jocote", 0.025f * producto.Cantidad },
                                    { "Azucar", 0.0875f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Sal", 0.05f * producto.Cantidad },
                                    { "Acido cítrico", 0.175f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                                            {"Sticker la chalupa", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractp08)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "P09":
                        Dictionary<string, float> ingredientsToSubtractp09 = new Dictionary<string, float>
                                {
                                    { "Jamaica", 0.0125f * producto.Cantidad },
                                    { "Azucar", 0.0875f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Sal", 0.025f * producto.Cantidad },
                                    { "Acido cítrico", 0.175f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                                            {"Sticker la rosa", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractp09)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "P10":
                        Dictionary<string, float> ingredientsToSubtractp10 = new Dictionary<string, float>
                                {
                                    { "Limón", 0.75f * producto.Cantidad },
                                    { "Hierba buena", 0.25f * producto.Cantidad },
                                    { "Azucar", 0.1f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Sal", 0.025f * producto.Cantidad },
                                    { "Acido cítrico", 0.175f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                                            {"Sticker el soldado", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractp10)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;

                    case "F01":
                        Dictionary<string, float> ingredientsToSubtractf01 = new Dictionary<string, float>
                                    {
                                        { "Fresa", 0.0625f * producto.Cantidad },
                                        { "Azucar", 0.0875f * producto.Cantidad },
                                        { "Sal", 0.05f * producto.Cantidad },
                                        { "Acido cítrico", 0.175f * producto.Cantidad },
                                        { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                        { "Paleta madera", 1f * producto.Cantidad },
                                        { "Emboltorio paleta", 1f * producto.Cantidad },
                                        { "Servilleta", 1f * producto.Cantidad },
                                        { "Sticker el diablito", 1f * producto.Cantidad }

                                    };

                        foreach (var ingredientEntry in ingredientsToSubtractf01)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "F02":
                        Dictionary<string, float> ingredientsToSubtractf02 = new Dictionary<string, float>
                                    {
                                        { "Naranja", 0.875f * producto.Cantidad },
                                        { "Azucar", 0.05f * producto.Cantidad },
                                        { "Sal", 0.025f * producto.Cantidad },
                                        { "Acido cítrico", 0.175f * producto.Cantidad },
                                        { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                        { "Paleta madera", 1f * producto.Cantidad },
                                        { "Emboltorio paleta", 1f * producto.Cantidad },
                                        { "Servilleta", 1f * producto.Cantidad },
                                        { "Sticker el cotorro", 1f * producto.Cantidad }
                                    };

                        foreach (var ingredientEntry in ingredientsToSubtractf02)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "F03":
                        Dictionary<string, float> ingredientsToSubtractf03 = new Dictionary<string, float>
                                    {
                                        { "Sandía grande", 0.025f * producto.Cantidad },
                                        { "Azucar", 0.05f * producto.Cantidad },
                                        { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                        { "Acido cítrico", 0.175f * producto.Cantidad },
                                        { "Paleta madera", 1f * producto.Cantidad },
                                        { "Emboltorio paleta", 1f * producto.Cantidad },
                                        { "Servilleta", 1f * producto.Cantidad },
                                        { "Sticker la sandillita", 1f * producto.Cantidad }
                                    };

                        foreach (var ingredientEntry in ingredientsToSubtractf03)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;

                    case "L01":
                        Dictionary<string, float> ingredientsToSubtractl01 = new Dictionary<string, float>
                                {
                                    { "Piña para fresco", 0.025f * producto.Cantidad },
                                    { "Limón", 0.075f * producto.Cantidad },
                                    { "Azucar", 0.075f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Sal", 0.05f * producto.Cantidad },
                                    { "Tequila", 0.025f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                    { "Sticker el valiente", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractl01)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }


                        break;
                    case "L02":
                        Dictionary<string, float> ingredientsToSubtractl02 = new Dictionary<string, float>
                                {
                                    { "Tamarindo", 0.025f * producto.Cantidad },
                                    { "Limón", 0.05f * producto.Cantidad },
                                    { "Azucar", 0.075f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Sal", 0.05f * producto.Cantidad },
                                    { "Cerveza", 0.1f * producto.Cantidad },
                                    { "Salsa inglesa", 0.05f * producto.Cantidad },
                                    { "Jugo de tomate", 0.025f * producto.Cantidad },
                                    { "Chile liquido", 0.0125f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                    { "Sticker el borracho", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractl02)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "L03":
                        Dictionary<string, float> ingredientsToSubtractl03 = new Dictionary<string, float>
                                {
                                    { "Fresa", 0.0625f * producto.Cantidad },
                                    { "Limón", 0.15f * producto.Cantidad },
                                    { "Soda mineral de limón", 0.05f * producto.Cantidad },
                                    { "Tajín", 0.0125f * producto.Cantidad },
                                    { "Sal", 0.05f * producto.Cantidad },
                                    { "Ron claro", 0.0375f * producto.Cantidad },
                                    { "Hierba buena", 1f * producto.Cantidad },
                                    { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                    { "Paleta madera", 1f * producto.Cantidad },
                                    { "Emboltorio paleta", 1f * producto.Cantidad },
                                    { "Servilleta", 1f * producto.Cantidad },
                                    { "Sticker el diablo", 1f * producto.Cantidad }
                                };

                        foreach (var ingredientEntry in ingredientsToSubtractl03)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;
                    case "L04":
                        Dictionary<string, float> ingredientsToSubtractl04 = new Dictionary<string, float>
                                    {
                                        { "Fresa", 0.025f * producto.Cantidad },
                                        { "Mora", 0.075f * producto.Cantidad },
                                        { "Hierba buena", 0.3f * producto.Cantidad },
                                        { "Azucar", 0.075f * producto.Cantidad },
                                        { "Escencia de coco", 0.05f * producto.Cantidad },
                                        { "Sal", 0.05f * producto.Cantidad },
                                        { "Estabilizador paleta de agua", 0.875f * producto.Cantidad },
                                        { "Paleta madera", 1f * producto.Cantidad },
                                        { "Emboltorio paleta", 1f * producto.Cantidad },
                                        { "Servilleta", 1f * producto.Cantidad },
                                        { "Sticker el cardenal", 1f * producto.Cantidad }
                                    };

                        foreach (var ingredientEntry in ingredientsToSubtractl04)
                        {
                            var response = ingredientsrepo.SubtractFromUnitByNameAndSubsidiary(
                                ingredientEntry.Key,
                                producto.Subsidiary_id,
                                ingredientEntry.Value
                            );

                            if (response.success == false)
                            {
                                Models.Products productsfaltantes = new Models.Products(ingredientEntry.Key,
                                    producto.Subsidiary_id, ingredientEntry.Value, response.returnType, $"none");
                                productosFaltantesList.Add(productsfaltantes);

                            }
                        }

                        break;

                    default:
                        break;
                }


            }
        }
    }
}
