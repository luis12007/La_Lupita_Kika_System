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
        private SubsidiaryRepository subsidiaryrepo;
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

        private void Subsidiary_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Subsidiary_cbb_Click(object sender, EventArgs e)
        {
            Products_cbb_OnSelectedIndexChanged(sender, e);
        }
    }
}
