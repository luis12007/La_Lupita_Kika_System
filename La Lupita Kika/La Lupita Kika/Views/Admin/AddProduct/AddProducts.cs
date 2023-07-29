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
        private List<string> clearlist = new List<string>();


        private UserRepository.PalettesRepository palettesrepo;
        private SnowIceRepository snowicerepo;
        private MangoneadasRepository mangoneadasrepo;
        private CandyRepository candysrepo;
        private OtherRepository otherrepo;
        private CategoryRepository categoryrepo;
        private CategoryCRepository categoryCrepo;
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
            add_manual.Visible = false;
            add_manual.Enabled = false;
            Codebar_label.Visible = false;
            Codebar_label.Enabled = false;
            Barcode_textbox.Visible = false;
            Barcode_textbox.Visible = false;
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

            switch (type)
            {
                case "Paletas":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    //view changes--------------------------------------------------------
                    add_manual.Visible = false;
                    add_manual.Enabled = false;
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
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
                    add_manual.Visible = false;
                    add_manual.Enabled = false;
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
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
                    List<string> namesmango = mangoneadasrepo.GetAllNames();
                    Name_cbb.DataSource = namesmango;

                    break;

                case "Helados":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    Name_cbb.DataSource = clearlist;
                    Category_cbb.DataSource = clearlist;
                    //view changes--------------------------------------------------------
                    add_manual.Visible = false;
                    add_manual.Enabled = false;
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
                    Category_cbb.Visible = false;
                    Cat_label.Visible = false;
                    name_label.Location = new Point(name_label.Location.X, 160);
                    Name_cbb.Location = new Point(Name_cbb.Location.X, 190);
                    Number_label.Location = new Point(Number_label.Location.X, 240);
                    Number_textbox.Location = new Point(Number_textbox.Location.X, 270);
                    //view changes--------------------------------------------------------

                    List<string> namesnow = snowicerepo.GetAllProductNames();
                    Name_cbb.DataSource = namesnow;

                    break;

                case "Dulces":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    Barcode_textbox.Texts = "";
                    Name_cbb.DataSource = clearlist;
                    Category_cbb.DataSource = clearlist;
                    //view changes--------------------------------------------------------
                    add_manual.Visible = true;
                    add_manual.Enabled = true;
                    Codebar_label.Visible = true;
                    Codebar_label.Enabled = true;
                    Barcode_textbox.Visible = true;
                    Barcode_textbox.Visible = true;
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    Barcode_textbox.Location = new Point(Barcode_textbox.Location.X, 490);
                    Codebar_label.Location = new Point(Codebar_label.Location.X, 450);
                    name_label.Location = new Point(name_label.Location.X, 250);
                    Name_cbb.Location = new Point(Name_cbb.Location.X, 280);
                    Number_label.Location = new Point(Number_label.Location.X, 330);
                    Number_textbox.Location = new Point(Number_textbox.Location.X, 360);
                    Number_label.Visible = false;
                    Number_label.Enabled = false;
                    Number_textbox.Visible = false;
                    Number_textbox.Enabled = false;
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

                    Codebar = Barcode_textbox.Texts;
                    break;

                case "Otros(snacks)":
                    Name_cbb.Texts = "Seleccionar";
                    Category_cbb.Texts = "Seleccionar";
                    Barcode_textbox.Texts = "";
                    Name_cbb.DataSource = clearlist;
                    Category_cbb.DataSource = clearlist;
                    //view changes--------------------------------------------------------
                    add_manual.Visible = true;
                    add_manual.Enabled = true;
                    Codebar_label.Visible = true;
                    Codebar_label.Enabled = true;
                    Barcode_textbox.Visible = true;
                    Barcode_textbox.Visible = true;
                    Category_cbb.Visible = false;
                    Cat_label.Visible = false;
                    Barcode_textbox.Location = new Point(Barcode_textbox.Location.X, 490);
                    Codebar_label.Location = new Point(Codebar_label.Location.X, 450);
                    name_label.Location = new Point(name_label.Location.X, 160);
                    Name_cbb.Location = new Point(Name_cbb.Location.X, 190);
                    Number_label.Location = new Point(Number_label.Location.X, 330);
                    Number_textbox.Location = new Point(Number_textbox.Location.X, 360);
                    Number_label.Visible = false;
                    Number_label.Enabled = false;
                    Number_textbox.Visible = false;
                    Number_textbox.Enabled = false;

                    //view changes--------------------------------------------------------

                    Codebar = Barcode_textbox.Texts;

                    List<string> namesother = otherrepo.GetAllNames();
                    Name_cbb.DataSource = namesother;
                    break;

                default:
                    //view changes--------------------------------------------------------
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
                    //view changes--------------------------------------------------------
                    break;
            }

            //-------------------------------------------code for dgv------------------------------------


        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            type = Products_cbb.SelectedItem.ToString();

            switch (type)
            {
                case "Paletas":
                    //view changes--------------------------------------------------------
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    //view changes--------------------------------------------------------
                    category = Category_cbb.SelectedItem.ToString();
                    Number = int.Parse(Number_textbox.Texts);

                    productName = Name_cbb.SelectedItem.ToString();

                    Palettes palette = palettesrepo.FindProductByName(productName);
                    if (palette == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductMango = productosList.FirstOrDefault(p =>
                        p.Nombre == palette.Name && p.Valor == palette.Price && p.Tipo == "Paletas");

                    if (existingProductMango != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductMango.Cantidad += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(palette.Name, Number, palette.Price, "Paletas", palette.Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }

                    break;

                case "Mangoneadas":
                    //view changes--------------------------------------------------------
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    //view changes-------------------------------------------------------
                    productName = Name_cbb.SelectedItem.ToString();
                    Number = int.Parse(Number_textbox.Texts);
                    Mangoneadas mango = mangoneadasrepo.FindByProductName(productName);
                    if (mango == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductpalette = productosList.FirstOrDefault(p =>
                        p.Nombre == mango.Name && p.Valor == mango.Price && p.Tipo == "Mangoneada");

                    if (existingProductpalette != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductpalette.Cantidad += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(mango.Name, Number, mango.Price, "Mangoneada", mango.Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }


                    break;

                case "Helados":

                    productName = Name_cbb.SelectedItem.ToString();
                    Number = int.Parse(Number_textbox.Texts);
                    SnowIce helado = snowicerepo.FindByName(productName);
                    if (helado == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductsnow = productosList.FirstOrDefault(p =>
                        p.Nombre == helado.Name && p.Valor == helado.Price && p.Tipo == "Helados");

                    if (existingProductsnow != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductsnow.Cantidad += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(helado.Name, Number, helado.Price, "Helados", helado.Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    break;

                case "Dulces":
                    Codebar = Barcode_textbox.Texts;

                    productName = Name_cbb.SelectedItem.ToString();
                    Candy dulce = candysrepo.FindByName(productName);
                    if (dulce == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }

                    Models.Products existingProductcandy = productosList.FirstOrDefault(p =>
                        p.Nombre == dulce.Name && p.Valor == dulce.Price && p.Tipo == "Dulces" && dulce.Codebar == p.Codebar);

                    if (existingProductcandy != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductcandy.Cantidad += Number;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(dulce.Name, 1, dulce.Price, "Dulces", Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    Barcode_textbox.Texts = "";
                    Barcode_textbox.Focus();
                    break;

                case "Otros(snacks)":
                    Codebar = Barcode_textbox.Texts;

                    productName = Name_cbb.SelectedItem.ToString();
                    Other other = otherrepo.FindByName(productName);
                    if (other == null)
                    {
                        MessageBox.Show("Producto no encontrado");
                        return;
                    }
                    // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                    Models.Products productothers = new Models.Products(other.Name, 1, other.Price, "Otros(snacks)", Codebar);
                    productosList.Add(productothers);

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Tipo}", palettec.Codebar };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    Barcode_textbox.Texts = "";
                    Barcode_textbox.Focus();
                    break;

                default:

                    break;
            }
        }

        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            Products_dataGridView.ColumnCount = 4;      // Columna para el nombre del producto
            Products_dataGridView.Columns[0].Name = "Nombre";
            Products_dataGridView.Columns[1].Name = "Cantidad";
            Products_dataGridView.Columns[2].Name = "tipo";
            Products_dataGridView.Columns[3].Name = "barcode";


            // Ajustar el ancho de las columnas
            Products_dataGridView.Columns["Nombre"].Width = 277;     // Establecer el ancho de la columna "Nombre" en 287 píxeles
            Products_dataGridView.Columns["Cantidad"].Width = 100;   // Establecer el ancho de la columna "Cantidad" en 100 píxeles
            Products_dataGridView.Columns["tipo"].Width = 110;      // Establecer el ancho de la columna "Valor" en 100 píxeles
            Products_dataGridView.Columns["barcode"].Width = 127;      // Establecer el ancho de la columna "Valor" en 100 píxeles

        }

        private void Category_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            type = Products_cbb.SelectedItem.ToString();

            switch (type)
            {
                case "Paletas":
                    //view changes--------------------------------------------------------
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    //view changes--------------------------------------------------------
                    category = Category_cbb.SelectedItem.ToString();

                    switch (category)
                    {
                        case "cremosas":
                            Name_cbb.DataSource = palettesrepo.GetNamesByCategoryId(1);
                            break;
                        case "picantes":
                            Name_cbb.DataSource = palettesrepo.GetNamesByCategoryId(2);
                            break;
                        case "fruta":
                            Name_cbb.DataSource = palettesrepo.GetNamesByCategoryId(3);
                            break;
                        case "licor":
                            Name_cbb.DataSource = palettesrepo.GetNamesByCategoryId(4);
                            break;
                        default:
                            // Acción por defecto si no coincide con ninguna categoría
                            break;
                    }


                    break;

                case "Helados":
                    //view changes--------------------------------------------------------
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;

                    break;

                case "Dulces":
                    //view changes--------------------------------------------------------
                    Codebar_label.Visible = true;
                    Codebar_label.Enabled = true;
                    Barcode_textbox.Visible = true;
                    Barcode_textbox.Visible = true;
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    Barcode_textbox.Location = new Point(Barcode_textbox.Location.X, 490);
                    Codebar_label.Location = new Point(Codebar_label.Location.X, 450);
                    //view changes--------------------------------------------------------


                    Codebar = Barcode_textbox.Texts;

                    category = Category_cbb.SelectedItem.ToString();

                    switch (category)
                    {
                        case "mejicanos":
                            Name_cbb.DataSource = candysrepo.FindNamesByCategory(1);
                            break;
                        case "chobo-banano":
                            Name_cbb.DataSource = candysrepo.FindNamesByCategory(2);
                            break;
                        case "otros":
                            Name_cbb.DataSource = candysrepo.FindNamesByCategory(3);
                            break;
                        default:
                            // Acción por defecto si no coincide con ninguna categoría
                            break;
                    }
                    break;

                case "Otros(snacks)":
                    //view changes--------------------------------------------------------
                    Codebar_label.Visible = true;
                    Codebar_label.Enabled = true;
                    Barcode_textbox.Visible = true;
                    Barcode_textbox.Visible = true;
                    Category_cbb.Visible = false;
                    Cat_label.Visible = false;
                    Barcode_textbox.Location = new Point(Barcode_textbox.Location.X, 200);
                    Codebar_label.Location = new Point(Codebar_label.Location.X, 170);
                    //view changes--------------------------------------------------------

                    Codebar = Barcode_textbox.Texts;
                    break;

                default:
                    //view changes--------------------------------------------------------
                    Category_cbb.Visible = true;
                    Cat_label.Visible = true;
                    Codebar_label.Visible = false;
                    Codebar_label.Enabled = false;
                    Barcode_textbox.Visible = false;
                    Barcode_textbox.Visible = false;
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
                        palettesrepo.UpdateCuantityByCodebarPlus(producto.Codebar, producto.Cantidad);
                        break;
                    case "Helados":
                        snowicerepo.IncrementCuantityByCodebarplus(producto.Codebar, producto.Cantidad);
                        break;
                    case "Mangoneada":
                        mangoneadasrepo.UpdateCuantityByCodebarplus(producto.Codebar, producto.Cantidad);
                        break;
                    case "Dulces":
                        Candy newcandy = new Candy(producto.Nombre, 1, producto.Valor, producto.Codebar);
                        candysrepo.Add(newcandy);
                        break;
                    case "Otros(snacks)":
                        Other newother = new Other(producto.Nombre, producto.Valor, producto.Codebar);
                        otherrepo.AddOther(newother);

                        break;
                    default:
                        MessageBox.Show("Error contacte a soporte");
                        break;
                }
            }
            MessageBox.Show("Agreagdo correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Products_dataGridView.Rows.Clear();
            Products_dataGridView.Refresh();
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
    }
}
