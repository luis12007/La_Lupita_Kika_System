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
        private List<Object> allObjects = new List<Object>();

        private bool shiftKeyPressed = false;

        private int thisregis;
        private float totalfrice = 0;
        private int subsidiary;
        private int cantidad = 1;

        public Facturation(String connectionString, int thisregis, int subsidiary)
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
            this.subsidiary = subsidiary;
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
            allObjects = new List<object>();

            allObjects.AddRange(mangoneadasrepo.FindBySubsidiaryId(subsidiary));
            allObjects.AddRange(palettesrepo.FindProductsBySubsidiaryId(subsidiary));
            allObjects.AddRange(snowicerepo.FindBySubsidiaryId(subsidiary));
            allObjects.AddRange(candysrepo.FindAllBySubsidiaryId(subsidiary));
            allObjects.AddRange(otherrepo.FindAllBySubsidiaryId(subsidiary));

            Barcode_textBox.Focus();
        }

        private void Add_button_Click_1(object sender, EventArgs e)
        {
            string Codebar = Barcode_textBox.Texts.ToUpper();

            // buscar segun codebar
            var foundObject = allObjects.FirstOrDefault(obj =>
            {
                if (obj is Mangoneadas mangoneadas)
                    return mangoneadas.Codebar == Codebar;
                if (obj is Models.Palettes palette)
                    return palette.Codebar == Codebar;
                if (obj is SnowIce snowice)
                    return snowice.Codebar == Codebar;
                if (obj is Candy candy)
                    return candy.Codebar == Codebar;
                if (obj is Other other)
                    return other.Codebar == Codebar;
                return false;
            });

            if (foundObject == null)
            {
                MessageBox.Show("producto no econtrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Barcode_textBox.Texts = "";
                Barcode_textBox.Focus();
                return;
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
                        existingProductMango.Cantidad += cantidad;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(mangoneadas.Name, cantidad, mangoneadas.Price, "Mangoneada", mangoneadas.Codebar);
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
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    totalfrice = (float)Math.Round(totalfrice, 2);

                    Total.Text = $"Total: {totalfrice}$";
                    break;

                case Models.Palettes palette:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProduct = productosList.FirstOrDefault(p =>
                        p.Nombre == palette.Name && p.Valor == palette.Price && p.Tipo == "palette");

                    if (existingProduct != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProduct.Cantidad += cantidad;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(palette.Name, cantidad, palette.Price, "palette", palette.Codebar);
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
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    totalfrice = (float)Math.Round(totalfrice, 2);

                    Total.Text = $"Total: {totalfrice}$";
                    break;

                case SnowIce snowice:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProductSnowice = productosList.FirstOrDefault(p =>
                        p.Nombre == snowice.Name && p.Valor == snowice.Price && p.Tipo == "snowice");

                    if (existingProductSnowice != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductSnowice.Cantidad += cantidad;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(snowice.Name, cantidad, snowice.Price, "snowice", snowice.Codebar);
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
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    totalfrice = (float)Math.Round(totalfrice, 2);

                    Total.Text = $"Total: {totalfrice}$";
                    break;

                case Candy candy:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProductCandy = productosList.FirstOrDefault(p =>
                        p.Nombre == candy.Name && p.Valor == candy.Price && p.Tipo == "candy");

                    if (existingProductCandy != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductCandy.Cantidad += cantidad;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(candy.Name, cantidad, candy.Price, "candy", candy.Codebar);
                        if (productpalette.Nombre == "JOLLY")
                        {
                            bool go = true;
                            for (int i = 1; i <= productpalette.Cantidad; i++) // Cambia el límite del ciclo según tus necesidades
                            {
                                if (i % 3 == 0 && go == true)
                                {
                                    go = false;
                                    MessageBox.Show("a ver");
                                    productpalette.Valor -= 0.0166666667f;
                                    productpalette.Valor = (float)Math.Round(productpalette.Valor, 2);
                                }
                            }
                        }
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
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    totalfrice = (float)Math.Round(totalfrice, 2);
                    Total.Text = $"Total: {totalfrice}$";
                    break;

                case Other other:
                    // Buscar si ya existe un objeto igual en productosList
                    Models.Products existingProductOther = productosList.FirstOrDefault(p =>
                    p.Nombre == other.Name && p.Valor == other.Price && p.Tipo == "other");

                    if (existingProductOther != null)
                    {
                        // Si existe un objeto igual, actualizar la cantidad a 2
                        existingProductOther.Cantidad += cantidad;
                    }
                    else
                    {
                        // Si no existe un objeto igual, agregar el nuevo objeto a la lista
                        Models.Products productpalette = new Models.Products(other.Name, cantidad, other.Price, "other", other.Codebar);
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
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    totalfrice = (float)Math.Round(totalfrice, 2);
                    Total.Text = $"Total: {totalfrice}$";

                    break;

                default:
                    // No se encontró el objeto con el código de barras en ninguno de los repositorios
                    totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);
                    totalfrice = (float)Math.Round(totalfrice, 2);
                    Total.Text = $"Total: {totalfrice}$";
                    MessageBox.Show("producto no econtrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Barcode_textBox.Texts = "";
                    break;
            }
            cantidad = 1;
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
            float totalfrices = 0;
            Total.Text = $"Total: {totalfrices}$";
            float totalfrice = productosList.Sum(producto => producto.Valor * producto.Cantidad);


            Products_dataGridView.Rows.Clear();
            this.Hide();
            // Abrir el nuevo formulario de facturación
            Staff.Mount formFacturation = new Staff.Mount(connectionString, totalfrice, productosList, thisregis, subsidiary);
            formFacturation.ShowDialog();

            this.Show();
            productosList.Clear();

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();

            // Abrir el nuevo formulario de facturación
            Staff.CashOutdit formFacturation = new Staff.CashOutdit(connectionString, thisregis, subsidiary );
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

        private async void Barcode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                shiftKeyPressed = true;
                await Task.Delay(10); // 500 milisegundos (0.5 segundos)
                Barcode_textBox.Texts = "";
            }

            if (shiftKeyPressed && Char.IsDigit(e.KeyChar) && e.KeyChar >= '1' && e.KeyChar <= '9')
            {
                cantidad = int.Parse(e.KeyChar.ToString());
                shiftKeyPressed = false;
                await Task.Delay(10); // 500 milisegundos (0.5 segundos)
                Barcode_textBox.Texts = "";
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al evento Login_button_Click
                Add_button.PerformClick();
            }

            if (e.KeyChar == (char)Keys.Space)
            {
                // Llamar al evento Login_button_Click
                Process_button.PerformClick();
            }
        }

        private void Add_button_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Space)
            {
                // Llamar al evento Login_button_Click
                Process_button.PerformClick();
            }


        }



        private void Facturation_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Barcode_textBox__TextChanged(object sender, EventArgs e)
        {

        }

        private void Barcode_textBox_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Barcode_textBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
