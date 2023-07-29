using Google.Protobuf.WellKnownTypes;
using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using La_Lupita_Kika.Views.Products.Palettes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static La_Lupita_Kika.Views.Facturation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace La_Lupita_Kika.Views
{
    public partial class Facturation : Form
    {
        private string connectionString;
        private UserRepository.PalettesRepository palettesrepo;
        private SnowIceRepository snowicerepo;
        private MangoneadasRepository mangoneadasrepo;
        private CandyRepository candysrepo;
        private RegisterRepository registerrepo;
        private RegisterXSalesRepository registerxsalesrepo;
        private SalesRepository salesrepo;
        private OtherRepository otherrepo;
        private List<Models.Products> productosList = new List<Models.Products>(); // Lista de productos

        private int thisregis;
        private float totalfrice = 0;

        public Facturation(String connectionString, int thisregis)
        {
            this.palettesrepo = new UserRepository.PalettesRepository(connectionString);
            this.snowicerepo = new SnowIceRepository(connectionString);
            this.mangoneadasrepo = new MangoneadasRepository(connectionString);
            this.candysrepo = new CandyRepository(connectionString);
            this.registerrepo = new RegisterRepository(connectionString);
            this.registerxsalesrepo = new RegisterXSalesRepository(connectionString);
            this.salesrepo = new SalesRepository(connectionString);
            this.otherrepo = new OtherRepository(connectionString);
            this.connectionString = connectionString;
            this.thisregis = thisregis;
            this.FormClosing += MyForm_FormClosing;
            InitializeComponent();
            InitializeDataGridView();
        }
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Verificar si el cierre del formulario fue provocado por el botón "X"
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Cancelar el cierre del formulario
                e.Cancel = true;
            }
        }

        private void Products_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Add_button_Click(object sender, EventArgs e)
        {

        }

        private void Corte_button_Click(object sender, EventArgs e)
        {

        }

        private void Facturation_Load(object sender, EventArgs e)
        {
            Barcode_textBox.Focus();
        }

        private void Add_button_Click_1(object sender, EventArgs e)
        {
            string Codebar = Barcode_textBox.Texts;

            List<Func<string, object>> repositories = new List<Func<string, object>>
                {
                 mangoneadasrepo.FindByCodebar,
                palettesrepo.FindByCodebar,
                snowicerepo.FindByCodebar,
                candysrepo.FindByCodebar,
                otherrepo.FindByCodebar
                };

            object foundObject = null;

            foreach (var repository in repositories)
            {
                foundObject = repository(Codebar);
                if (foundObject != null)
                {
                    // Se encontró el objeto con el código de barras en este repositorio
                    break;
                }
            }

            switch (foundObject)
            {
                case Mangoneadas mangoneadas:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProductMango = productosList.FirstOrDefault(p =>
                        p.Nombre == mangoneadas.Name && p.Valor == mangoneadas.Price && p.Tipo == "Mangoneada");

                    if (existingProductMango != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductMango.Cantidad += 1;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(mangoneadas.Name, 1, mangoneadas.Price, "Mangoneada", mangoneadas.Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Valor * palettec.Cantidad}" };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    mangoneadasrepo.UpdateCuantityByCodebarmin(mangoneadas.Codebar,1);
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    Total.Text = $"Total: {totalfrice}$";
                    break;

                case Models.Palettes palette:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProduct = productosList.FirstOrDefault(p =>
                        p.Nombre == palette.Name && p.Valor == palette.Price && p.Tipo == "palette");

                    if (existingProduct != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProduct.Cantidad += 1;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(palette.Name, 1, palette.Price, "palette", palette.Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Valor * palettec.Cantidad}" };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    palettesrepo.UpdateCuantityByCodebarmin(palette.Codebar, 1);
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    Total.Text = $"Total: {totalfrice}$";
                    break;

                case SnowIce snowice:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProductSnowice = productosList.FirstOrDefault(p =>
                        p.Nombre == snowice.Name && p.Valor == snowice.Price && p.Tipo == "snowice");

                    if (existingProductSnowice != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductSnowice.Cantidad += 1;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(snowice.Name, 1, snowice.Price, "snowice", snowice.Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Valor * palettec.Cantidad}" };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    snowicerepo.IncrementCuantityByCodebarmin(snowice.Codebar,1);
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    Total.Text = $"Total: {totalfrice}$";
                    break;

                case Candy candy:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProductCandy = productosList.FirstOrDefault(p =>
                        p.Nombre == candy.Name && p.Valor == candy.Price && p.Tipo == "candy");

                    if (existingProductCandy != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductCandy.Cantidad += 1;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(candy.Name, 1, candy.Price, "candy", candy.Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Valor * palettec.Cantidad}" };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    candysrepo.DeleteByCodebar(candy.Codebar);
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    Total.Text = $"Total: {totalfrice}$";
                    break;

                case Other other:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProductOther = productosList.FirstOrDefault(p =>
                    p.Nombre == other.Name && p.Valor == other.Price && p.Tipo == "other");

                    if (existingProductOther != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductOther.Cantidad += 1;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(other.Name, 1, other.Price, "other", other.Codebar);
                        productosList.Add(productpalette);
                    }

                    Products_dataGridView.Rows.Clear();
                    foreach (var palettec in productosList)
                    {
                        // Crear un nuevo String[] con los valores de cada elemento en la lista
                        String[] row2 = { palettec.Nombre, $"{palettec.Cantidad}", $"{palettec.Valor * palettec.Cantidad}" };

                        // Agregar el nuevo String[] a Products_dataGridView.Rows
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();
                    }
                    otherrepo.DeleteByCodebar(other.Codebar);
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    Total.Text = $"Total: {totalfrice}$";

                    break;

                default:
                    // No se encontró el objeto con el código de barras en ninguno de los repositorios
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    Total.Text = $"Total: {totalfrice}$";
                    MessageBox.Show("producto no econtrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            Barcode_textBox.Texts = "";
            Barcode_textBox.Focus();
        }

        private void Facturation_Shown(object sender, EventArgs e)
        {
            Barcode_textBox.Focus();
        }

        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            Products_dataGridView.ColumnCount = 3;      // Columna para el nombre del producto
            Products_dataGridView.Columns[0].Name = "Nombre";
            Products_dataGridView.Columns[1].Name = "Cantidad";
            Products_dataGridView.Columns[2].Name = "Valor";

            // Ajustar el ancho de las columnas
            Products_dataGridView.Columns["Nombre"].Width = 287;     // Establecer el ancho de la columna "Nombre" en 287 píxeles
            Products_dataGridView.Columns["Cantidad"].Width = 100;   // Establecer el ancho de la columna "Cantidad" en 100 píxeles
            Products_dataGridView.Columns["Valor"].Width = 100;      // Establecer el ancho de la columna "Valor" en 100 píxeles

        }

        private void Products_dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Products_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Products_dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void Process_button_Click(object sender, EventArgs e)
        {
            if (productosList.IsNullOrEmpty())
            {
                MessageBox.Show("Sin productos para procesar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Supongamos que tienes una instancia del repositorio SalesRepository llamada salesrepo
            foreach (var producto in productosList)
            {
                int registers = thisregis;
                // Obtener los datos de cada producto en la lista
                string nombre = producto.Nombre;
                int cantidad = producto.Cantidad;
                float precio = producto.Valor;


                // Llamar al método Add del repositorio SalesRepository para guardar los datos en la base de datos
                Sales sales = new Sales(nombre, cantidad, precio);
                salesrepo.Add(sales);

                float totalfrices = 0;
                Total.Text = $"Total: {totalfrices}$";
                List<Sales> salesList = salesrepo.GetAll();
                Sales foundSales = salesList.Find(sales => sales.Name.Equals(nombre) && sales.Lot.Equals(cantidad));

                // Obtener el ID del objeto Sales encontrado
                int foundId = foundSales != null ? foundSales.Id : -1;

                if (foundId != -1)
                {
                    Registerxsales register = new Registerxsales(registers, foundId);
                    registerxsalesrepo.Add(register);
                }


            }

            float totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);


            Products_dataGridView.Rows.Clear();

            MessageBox.Show("El Monto total es: " + $"{totalfrice}$", "Monto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            // Abrir el nuevo formulario de facturación
            Staff.Mount formFacturation = new Staff.Mount(connectionString, totalfrice, productosList, thisregis);
            formFacturation.ShowDialog();
            productosList.Clear();


            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();

            // Abrir el nuevo formulario de facturación
            Staff.CashOutdit formFacturation = new Staff.CashOutdit(connectionString, thisregis);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Products_dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                // Eliminar la fila del DataGridView

                string nombreProducto = Products_dataGridView.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                Models.Products productoEncontrado = productosList.FirstOrDefault(p => p.Nombre == nombreProducto);

                //reagregar
                switch (productoEncontrado.Tipo)
                {
                    case "candy":
                        Candy readdC = new Candy(productoEncontrado.Nombre, 1, productoEncontrado.Valor, productoEncontrado.Codebar);
                        candysrepo.Add(readdC);
                        break;

                    case "other":
                        Other readdO = new Other(productoEncontrado.Nombre, productoEncontrado.Valor, productoEncontrado.Codebar);
                        otherrepo.AddOther(readdO);
                        break;

                    case "Mangoneada":
                        mangoneadasrepo.UpdateCuantityByCodebarplus(productoEncontrado.Codebar, 1);
                        break;

                    case "palette":
                        palettesrepo.UpdateCuantityByCodebarPlus(productoEncontrado.Codebar, 1);
                        break;

                    case "snowice":
                        snowicerepo.IncrementCuantityByCodebarplus(productoEncontrado.Codebar, 1);
                        break;

                    default:
                        break;
                }
                //---------------------------------------------------------------

                productosList.RemoveAll(p => p.Nombre == nombreProducto);

                Products_dataGridView.Rows.RemoveAt(e.RowIndex);

                Products_dataGridView.ClearSelection();
                Products_dataGridView.Refresh();
                Barcode_textBox.Focus();
                totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                Total.Text = $"Total: {totalfrice}$";
            }
        }

        private void Barcode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
