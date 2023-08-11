using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.Logging;
using OfficeOpenXml;
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
    public partial class Gains : Form
    {
        private string ConnectionString;
        private SubsidiaryRepository SubsidiaryRepository;
        private SalesRepository SalesRepository;
        private RegisterXSalesRepository RegisterXSalesRepository;
        private RegisterRepository RegisterRepository;
        private UserRepository.UserRepository userRepository;
        private string Subsidiarytext = "Sonsonate";
        private int subsidiaryNumber = 1;

        private List<SalesWithRegisterData> registrosEncontrados = new List<SalesWithRegisterData>();
        public Gains(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.SubsidiaryRepository = new SubsidiaryRepository(connectionString);
            this.RegisterRepository = new RegisterRepository(connectionString);
            this.SalesRepository = new SalesRepository(connectionString);
            this.RegisterXSalesRepository = new RegisterXSalesRepository(connectionString);
            this.userRepository = new UserRepository.UserRepository(connectionString);
            InitializeComponent();
            InitializeDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Gains_Load(object sender, EventArgs e)
        {
            List<Subsidiary> subsidiary = SubsidiaryRepository.GetAll();

            // Crear una lista que contenga los nombres de las subsidiarias
            List<string> subsidiaryNames = new List<string>();

            // Recorrer la lista de subsidiarias y agregar los nombres a la lista
            foreach (var sub in subsidiary)
            {
                subsidiaryNames.Add(sub.Name);
            }
            subsidiaryNames.Add("Todos");
            // Asignar la lista como fuente de datos del ComboBox
            Subsidiary_cbb.DataSource = subsidiaryNames;

            Subsidiarytext = Subsidiary_cbb.SelectedItem.ToString();
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            registrosEncontrados.Clear();
            registrosEncontrados = RegisterRepository.GetSalesWithRegisterDataByDateRange(startDate, endDate, subsidiaryNumber);

           
            if (registrosEncontrados.IsNullOrEmpty())
            {
                return;
            }
            RefreshDGV();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Subsidiarytext = Subsidiary_cbb.SelectedItem.ToString();
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            registrosEncontrados.Clear();
            GetSbusidiary(Subsidiarytext);
            if (subsidiaryNumber == 3)
            {
                // Llamada 1
                List<SalesWithRegisterData> registrosEncontradosSubsidiary1 = RegisterRepository.GetSalesWithRegisterDataByDateRange(startDate, endDate, 1);
                registrosEncontrados.AddRange(registrosEncontradosSubsidiary1);

                // Llamada 2
                List<SalesWithRegisterData> registrosEncontradosSubsidiary2 = RegisterRepository.GetSalesWithRegisterDataByDateRange(startDate, endDate, 2);
                registrosEncontrados.AddRange(registrosEncontradosSubsidiary2);
                RefreshDGV();
                return;
            }


            registrosEncontrados = RegisterRepository.GetSalesWithRegisterDataByDateRange(startDate, endDate, subsidiaryNumber);
            
            if (registrosEncontrados.IsNullOrEmpty())
            {
                MessageBox.Show("No registros encontrados para este rango.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RefreshDGV();
        }



        private void GetSbusidiary(string subsi)
        {
            switch (subsi)
            {
                case "Sonsonate":

                    subsidiaryNumber = 1;
                    break;

                case "Juayua":

                    subsidiaryNumber = 2;

                    break;

                case "Todos":

                    subsidiaryNumber = 3;
                    break;

                default:
                    subsidiaryNumber = 1;
                    break;

            }
        }
        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            dataGridView1.ColumnCount = 5;      // Columna para el nombre del producto
            dataGridView1.Columns[0].Name = "Nombre";
            dataGridView1.Columns[1].Name = "Cantidad";
            dataGridView1.Columns[2].Name = "Unidad";
            dataGridView1.Columns[3].Name = "Total";
            dataGridView1.Columns[4].Name = "Cajero";



            // Ajustar el ancho de las columnas
            dataGridView1.Columns["Nombre"].Width = 293;
            dataGridView1.Columns["Cantidad"].Width = 115;
            dataGridView1.Columns["Unidad"].Width = 140;
            dataGridView1.Columns["Total"].Width = 140;
            dataGridView1.Columns["Cajero"].Width = 150;

        }

        private void RefreshDGV()
        {
            dataGridView1.Rows.Clear();
            float totalSum = 0; // Variable para almacenar la suma de los resultados

            foreach (var palettec in registrosEncontrados)
            {
                float rowTotal = palettec.Lot * palettec.Total;
                totalSum += rowTotal; // Agregar el resultado actual a la suma total

                String[] row2 = { palettec.ProductName, $"{palettec.Lot}", $"{palettec.Total}",
            $"{rowTotal}", $"{palettec.UserId}" };
                dataGridView1.Rows.Add(row2);
                dataGridView1.ClearSelection();
            }

            HashSet<string> nombresUnicos = new HashSet<string>();

            foreach (var registro in registrosEncontrados)
            {
                nombresUnicos.Add(registro.ProductName);
            }

            List<string> nombresProductosUnicos = nombresUnicos.ToList();

            Sum_cbb.DataSource = nombresProductosUnicos;

            // Actualizar el texto del Total_label con la suma total calculada
            Total_label.Text = $"Total: {totalSum}$";
            Sum_label.Text = $"Recuento: 0";

        }

        private void Excel_Button_Click(object sender, EventArgs e)
        {

            List<Models.SalesWithRegisterData> productosListexcel = new List<Models.SalesWithRegisterData>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Verifica si no es una fila nueva (fila en blanco para agregar datos)
                {
                    Models.SalesWithRegisterData producto = new Models.SalesWithRegisterData
                    {
                        ProductName = row.Cells["Nombre"].Value.ToString(),
                        Lot = float.Parse(row.Cells["Cantidad"].Value.ToString()),
                        Total = float.Parse(row.Cells["Unidad"].Value.ToString()),
                        totalpluslot = (float.Parse(row.Cells["Cantidad"].Value.ToString()) * float.Parse(row.Cells["Unidad"].Value.ToString())),
                        UserId = int.Parse(row.Cells["Cajero"].Value.ToString()),
                    };

                    productosListexcel.Add(producto);
                }
            }
            //MessageBox.Show("aver");

            // Obtener la ruta de la carpeta "Documentos" del usuario
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Crear el nombre del archivo Excel
            string nombreArchivo = "Ganancias.xlsx";
            string rutaArchivo = Path.Combine(documentsPath, nombreArchivo);

            GuardarEnExcel(productosListexcel, rutaArchivo);
        }
        public void GuardarEnExcel(List<Models.SalesWithRegisterData> productosList, string rutaArchivo)
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
                var worksheet = package.Workbook.Worksheets.Add("Ganancias");

                // Escribir los encabezados de las columnas
                worksheet.Cells[1, 1].Value = "Nombre";
                worksheet.Cells[1, 2].Value = "Cantidad";
                worksheet.Cells[1, 3].Value = "Unidad";
                worksheet.Cells[1, 4].Value = "Subtotal";
                worksheet.Cells[1, 5].Value = "Cajero";

                // Escribir los datos de la lista en las celdas
                int rowIndex = 2;
                foreach (var producto in productosList)
                {
                    worksheet.Cells[rowIndex, 1].Value = producto.ProductName;
                    worksheet.Cells[rowIndex, 2].Value = producto.Lot;
                    worksheet.Cells[rowIndex, 3].Value = producto.Total;
                    worksheet.Cells[rowIndex, 4].Value = producto.totalpluslot;
                    worksheet.Cells[rowIndex, 5].Value = producto.UserId;

                    rowIndex++;
                }

                MessageBox.Show("Guardado.", "Procesado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Guardar los cambios en el archivo
                package.Save();
            }
        }

        private void Sum_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            string nombreBuscado = Sum_cbb.SelectedItem.ToString();
            float sumaLot = 0;

            foreach (var registro in registrosEncontrados)
            {
                if (registro.ProductName == nombreBuscado)
                {
                    sumaLot += registro.Lot;
                }
            }
            Sum_label.Text = $"Recuento: {sumaLot}";
        }

        private void Subsidiary_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Subsidiary_cbb.SelectedItem.ToString()) {
                case "Sonsonate":
                    subsidiaryNumber = 1;
                    break;

                case "Juayua":
                    subsidiaryNumber = 2;
                    break;

                case "Todos":
                    subsidiaryNumber = 3;
                    break;

                default
                    : break;
            }
        }
    }
}
