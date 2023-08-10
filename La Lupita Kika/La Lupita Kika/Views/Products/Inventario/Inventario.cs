using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using La_Lupita_Kika.Views.Admin.User;
using La_Lupita_Kika.Views.Products.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace La_Lupita_Kika.Views.Products.Palettes
{
    public partial class Inventario : Form
    {
        private string ConnectionString;
        private MangoneadasRepository MangoneadasRepository;
        private PalettesRepository PalettesRepository;
        private SnowIceRepository SnowIceRepository;
        private CandyRepository CandyRepository;
        private OtherRepository OtherRepository;
        private SubsidiaryRepository SubsidiaryRepository;
        private CategoryRepository categorepo;
        private CategoryCRepository categoryCRepository;
        private string type;
        private string subsidiary;
        private int subsidiarynumber;
        private string Subsidiarynone;
        private string Categorynone;
        private string findtext;
        private Models.Products productselected = new Models.Products();
        public Inventario(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.MangoneadasRepository = new MangoneadasRepository(connectionString);
            this.PalettesRepository = new PalettesRepository(connectionString);
            this.SnowIceRepository = new SnowIceRepository(connectionString);
            this.CandyRepository = new CandyRepository(connectionString);
            this.OtherRepository = new OtherRepository(connectionString);
            this.SubsidiaryRepository = new SubsidiaryRepository(connectionString);
            this.categorepo = new CategoryRepository(connectionString);
            this.categoryCRepository = new CategoryCRepository(connectionString);
            InitializeComponent();
            InitializeDataGridView();
        }


        private async void Inventario_Load(object sender, EventArgs e)
        {
            await LoadInventarioAsync();
        }

        private async Task LoadInventarioAsync()
        {
            
            List<Subsidiary> subsidiary = await SubsidiaryRepository.GetAllAsync();

            // Crear una lista que contenga los nombres de las subsidiarias
            List<string> subsidiaryNames = new List<string>();

            // Recorrer la lista de subsidiarias y agregar los nombres a la lista
            foreach (var sub in subsidiary)
            {
                subsidiaryNames.Add(sub.Name);
            }
            subsidiaryNames.Add("Todos");

            // Asignar la lista como fuente de datos del ComboBox
            subsidiary_cbb.DataSource = subsidiaryNames;
            RefreshDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        //Utils-----------------------------------------

        private void RefreshDGV()
        {
            Products_cbb.SelectedIndex = 0;

            List<Models.Palettes> palettes = PalettesRepository.FindProductsBySubsidiaryId(subsidiarynumber);
            Products_dataGridView.Rows.Clear();

            if (subsidiary == "Todos")
            {
                palettes = PalettesRepository.GetAll();
            }

            foreach (var palettec in palettes)
            {
                switch (palettec.Subsidiary_ID)
                {
                    case 1:
                        Categorynone = "Cremosas";
                        break;

                    case 2:
                        Categorynone = "Picantes";
                        break;

                    case 3:
                        Categorynone = "Fruta";
                        break;

                    case 4:
                        Categorynone = "Licor";
                        break;

                    default:
                        break;

                }
                String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{palettec.Subsidiary_ID}" };
                Products_dataGridView.Rows.Add(row2);
                Products_dataGridView.ClearSelection();

            }
        }

        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            Products_dataGridView.ColumnCount = 6;      // Columna para el nombre del producto
            Products_dataGridView.Columns[0].Name = "Nombre";
            Products_dataGridView.Columns[1].Name = "Precio";
            Products_dataGridView.Columns[2].Name = "Codebar";
            Products_dataGridView.Columns[3].Name = "Categoria";
            Products_dataGridView.Columns[4].Name = "Cantidad";
            Products_dataGridView.Columns[5].Name = "Sucursal";



            // Ajustar el ancho de las columnas
            Products_dataGridView.Columns["Nombre"].Width = 290;
            Products_dataGridView.Columns["Precio"].Width = 115;
            Products_dataGridView.Columns["Codebar"].Width = 140;
            Products_dataGridView.Columns["Categoria"].Width = 200;
            Products_dataGridView.Columns["Cantidad"].Width = 120;
            Products_dataGridView.Columns["Sucursal"].Width = 120;

        }

        private void Products_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Products_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            type = Products_cbb.SelectedItem.ToString();
            subsidiary = subsidiary_cbb.SelectedItem.ToString();
            if (subsidiary != "Todos")
            {
                subsidiarynumber = SubsidiaryRepository.FindIdByName(subsidiary);
            }

            CasesInventory();
        }

        private void subsidiary_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Products_cbb.SelectedItem == null)
            {
                type = "Paletas";
            }
            else if (Products_cbb.SelectedItem != null)
            {
                type = Products_cbb.SelectedItem.ToString();
            }
            Subsidiarynone = subsidiary_cbb.SelectedItem.ToString();
            switch (Subsidiarynone)
            {
                case "Sonsonate":
                    subsidiarynumber = 1;
                    subsidiary = "Sonsonate";
                    RefreshDGV();
                    break;

                case "Juayua":
                    subsidiarynumber = 2;
                    subsidiary = "Juayua";
                    RefreshDGV();
                    break;

                case "Todos":
                    subsidiary = "Todos";
                    RefreshDGV();
                    break;

            }

        }

        private void CasesInventory()
        {
            if (Products_cbb.SelectedItem == null)
            {
                type = "Paletas";
            }
            else if (Products_cbb.SelectedItem != null)
            {
                type = Products_cbb.SelectedItem.ToString();
            }
            switch (type)
            {
                case "Paletas":

                    List<Models.Palettes> palettes = PalettesRepository.FindProductsBySubsidiaryId(subsidiarynumber);
                    Products_dataGridView.Rows.Clear();

                    if (subsidiary == "Todos")
                    {
                        palettes = PalettesRepository.GetAll();
                    }

                    Subsidiarynone = "none";
                    Categorynone = "none";
                    foreach (var palettec in palettes)
                    {
                        switch (palettec.Category_Id) {
                            case 1:
                                Categorynone = "Cremosas";
                                break;

                            case 2:
                                Categorynone = "Picantes";
                                break;

                            case 3:
                                Categorynone = "Fruta";
                                break;

                            case 4:
                                Categorynone = "Licor";
                                break;

                            default:
                                break;

                        }
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{palettec.Subsidiary_ID}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }
                    break;

                case "Mangoneadas":
                    List<Models.Mangoneadas> Mangoneadas = MangoneadasRepository.FindBySubsidiaryId(subsidiarynumber);

                    if (subsidiary == "Todos")
                    {
                        Mangoneadas = MangoneadasRepository.GetAll();
                    }
                    Products_dataGridView.Rows.Clear();

                    Subsidiarynone = "none";
                    Categorynone = "Mangoneada";
                    foreach (var palettec in Mangoneadas)
                    {
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", "Mangoneada", $"{palettec.Cuantity}", $"{palettec.Subsidiary_ID}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }
                    break;

                case "Helados":
                    List<Models.SnowIce> snowIce = SnowIceRepository.FindBySubsidiaryId(subsidiarynumber);
                    Products_dataGridView.Rows.Clear();


                    if (subsidiary == "Todos")
                    {
                        snowIce = SnowIceRepository.GetAll();
                    }
                    Categorynone = "none";
                    foreach (var palettec in snowIce)
                    {
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{palettec.Subsidiary_ID}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }

                    break;

                case "Dulces":
                    List<Models.Candy> candys = CandyRepository.FindAllBySubsidiaryId(subsidiarynumber);
                    Products_dataGridView.Rows.Clear();

                    if (subsidiary == "Todos")
                    {
                        candys = CandyRepository.GetAll();
                    }

                    

                    Subsidiarynone = "none";
                    Categorynone = "none";
                    foreach (var palettec in candys)
                    {
                        switch (palettec.Category_id)
                        {
                            case 1:
                                Categorynone = "Mejicanos";
                                break;

                            case 2:
                                Categorynone = "Otros";
                                break;

                            default:
                                break;

                        }
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{palettec.Subsidiary_ID}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }

                    break;

                case "Otros(snacks)":
                    List<Models.Other> others = OtherRepository.FindAllBySubsidiaryId(subsidiarynumber);
                    Products_dataGridView.Rows.Clear();

                    if (subsidiary == "Todos")
                    {
                        others = OtherRepository.GetAllOthers();
                    }

                    Subsidiarynone = "none";
                    Categorynone = "none";
                    foreach (var palettec in others)
                    {
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{palettec.Subsidiary_ID}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }

                    break;

                default:

                    break;
            }

            Find.Texts = "";
        }

        private void Find__TextChanged(object sender, EventArgs e)
        {
        }


        private void rjButton1_Click(object sender, EventArgs e)
        {
            List<Models.Products> productosList = new List<Models.Products>();

            foreach (DataGridViewRow row in Products_dataGridView.Rows)
            {
                if (!row.IsNewRow) // Verifica si no es una fila nueva (fila en blanco para agregar datos)
                {
                    int number = SubsidiaryRepository.FindIdByName(row.Cells["Sucursal"].Value.ToString());
                    Models.Products producto = new Models.Products
                    {
                        Nombre = row.Cells["Nombre"].Value.ToString(),
                        Valor = float.Parse(row.Cells["Precio"].Value.ToString()),
                        Codebar = row.Cells["Codebar"].Value.ToString(),
                        Tipo = row.Cells["Categoria"].Value.ToString(),
                        Cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString()),
                        Subsidiary_id = number,
                    };

                    productosList.Add(producto);
                }
            }
            MessageBox.Show("aver");

            // Obtener la ruta de la carpeta "Documentos" del usuario
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Crear el nombre del archivo Excel
            string nombreArchivo = "productos.xlsx";
            string rutaArchivo = Path.Combine(documentsPath, nombreArchivo);

            GuardarEnExcel(productosList, rutaArchivo);

        }

        private void Products_dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Verificar que se haya hecho clic en una fila válida
            {
                // Obtener el valor de la celda correspondiente al nombre (suponiendo que está en la primera columna)

                DataGridViewRow row = Products_dataGridView.Rows[e.RowIndex];
                productselected.Nombre = row.Cells["Nombre"].Value.ToString();
                productselected.Valor = float.Parse(row.Cells["Precio"].Value.ToString());
                productselected.Codebar = row.Cells["Codebar"].Value.ToString();
                productselected.catego = row.Cells["Categoria"].Value.ToString();
                productselected.Cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString());
                int numberProduct = SubsidiaryRepository.FindIdByName(row.Cells["Sucursal"].Value.ToString());
                productselected.Tipo = Products_cbb.Texts;
                productselected.Subsidiary_id = numberProduct;

            }

            EditProduct formFacturation = new EditProduct(ConnectionString, productselected);
            formFacturation.ShowDialog();

            CasesInventory();
            Products_cbb.SelectedIndex = 1;
            Products_cbb.SelectedIndex = 0;
            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        public void GuardarEnExcel(List<Models.Products> productosList, string rutaArchivo)
        {
            // Verificar si el archivo existe y eliminarlo si es necesario
            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
            }
            // Crear el archivo Excel
            using (var package = new ExcelPackage(new FileInfo(rutaArchivo)))
            {
                // Crear una nueva hoja en el archivo
                var worksheet = package.Workbook.Worksheets.Add("Productos");

                // Escribir los encabezados de las columnas
                worksheet.Cells[1, 1].Value = "Nombre";
                worksheet.Cells[1, 2].Value = "Precio";
                worksheet.Cells[1, 3].Value = "Codebar";
                worksheet.Cells[1, 4].Value = "Categoria";
                worksheet.Cells[1, 5].Value = "Cantidad";
                worksheet.Cells[1, 6].Value = "Sucursal";

                // Escribir los datos de la lista en las celdas
                int rowIndex = 2;
                foreach (var producto in productosList)
                {
                    worksheet.Cells[rowIndex, 1].Value = producto.Nombre;
                    worksheet.Cells[rowIndex, 2].Value = producto.Valor;
                    worksheet.Cells[rowIndex, 3].Value = producto.Codebar;
                    worksheet.Cells[rowIndex, 4].Value = producto.Tipo;
                    worksheet.Cells[rowIndex, 5].Value = producto.Cantidad;
                    worksheet.Cells[rowIndex, 6].Value = producto.Subsidiary_id;

                    rowIndex++;
                }

                // Guardar los cambios en el archivo
                package.Save();
            }
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            AddInventario inventario = new AddInventario(ConnectionString);
            inventario.ShowDialog();


            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = Products_cbb.SelectedItem.ToString();
            subsidiary = subsidiary_cbb.SelectedItem.ToString();
            findtext = Find.Texts;
            if (subsidiary != "Todos")
            {
                subsidiarynumber = SubsidiaryRepository.FindIdByName(subsidiary);
            }

            switch (type)
            {
                case "Paletas":

                    List<Models.Palettes> palettes = PalettesRepository.FindProductsBySubsidiaryId2(subsidiarynumber, findtext);
                    Products_dataGridView.Rows.Clear();

                    if (subsidiary == "Todos")
                    {
                        palettes = PalettesRepository.GetAllfind(findtext);
                    }

                    Subsidiarynone = "none";
                    Categorynone = "none";
                    foreach (var palettec in palettes)
                    {
                        Subsidiarynone = SubsidiaryRepository.FindNameById(palettec.Subsidiary_ID);
                        Categorynone = categorepo.FindNameById(palettec.Category_Id);
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{Subsidiarynone}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }
                    break;

                case "Mangoneadas":
                    List<Models.Mangoneadas> Mangoneadas = MangoneadasRepository.FindMangoneadasBySubsidiaryId(subsidiarynumber, findtext);

                    if (subsidiary == "Todos")
                    {
                        Mangoneadas = MangoneadasRepository.FindAllMangoneadas(findtext);
                    }
                    Products_dataGridView.Rows.Clear();

                    Subsidiarynone = "none";
                    Categorynone = "none";
                    foreach (var palettec in Mangoneadas)
                    {
                        Subsidiarynone = SubsidiaryRepository.FindNameById(palettec.Subsidiary_ID);
                        Categorynone = categorepo.FindNameById(palettec.Category_id);
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{Subsidiarynone}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }
                    break;

                case "Helados":
                    List<Models.SnowIce> snowIce = SnowIceRepository.FindBySubsidiaryIdfind(subsidiarynumber, findtext);
                    Products_dataGridView.Rows.Clear();


                    if (subsidiary == "Todos")
                    {
                        snowIce = SnowIceRepository.GetAllFind(findtext);
                    }


                    Subsidiarynone = "none";
                    Categorynone = "none";
                    foreach (var palettec in snowIce)
                    {
                        Subsidiarynone = SubsidiaryRepository.FindNameById(palettec.Subsidiary_ID);
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{Subsidiarynone}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }

                    break;

                case "Dulces":
                    List<Models.Candy> candys = CandyRepository.FindAllBySubsidiaryIdFind(subsidiarynumber, findtext);
                    Products_dataGridView.Rows.Clear();

                    if (subsidiary == "Todos")
                    {
                        candys = CandyRepository.GetAllFind(findtext);
                    }

                    Subsidiarynone = "none";
                    Categorynone = "none";
                    foreach (var palettec in candys)
                    {
                        Subsidiarynone = SubsidiaryRepository.FindNameById(palettec.Subsidiary_ID);
                        Categorynone = categoryCRepository.FindNameById(palettec.Category_id);
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{Subsidiarynone}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }

                    break;

                case "Otros(snacks)":
                    List<Models.Other> others = OtherRepository.FindAllBySubsidiaryIdFind(subsidiarynumber, findtext);
                    Products_dataGridView.Rows.Clear();

                    if (subsidiary == "Todos")
                    {
                        others = OtherRepository.GetAllOthersFind(findtext);
                    }

                    Subsidiarynone = "none";
                    Categorynone = "none";
                    foreach (var palettec in others)
                    {
                        Subsidiarynone = SubsidiaryRepository.FindNameById(palettec.Subsidiary_ID);
                        String[] row2 = { palettec.Name, $"{palettec.Price}", $"{palettec.Codebar}", $"{Categorynone}", $"{palettec.Cuantity}", $"{Subsidiarynone}" };
                        Products_dataGridView.Rows.Add(row2);
                        Products_dataGridView.ClearSelection();

                    }

                    break;

                default:
                    MessageBox.Show("no productos encontrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
