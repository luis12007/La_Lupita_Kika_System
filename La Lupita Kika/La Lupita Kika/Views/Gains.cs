using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
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
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            registrosEncontrados = RegisterRepository.GetSalesWithRegisterDataByDateRange(startDate, endDate, 1);
            RefreshDGV();
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
            dataGridView1.Columns["Nombre"].Width = 260;
            dataGridView1.Columns["Cantidad"].Width = 115;
            dataGridView1.Columns["Unidad"].Width = 140;
            dataGridView1.Columns["Total"].Width = 200;
            dataGridView1.Columns["Cajero"].Width = 150;

        }

        private void RefreshDGV()
        {
            dataGridView1.Rows.Clear();

            foreach (var palettec in registrosEncontrados)
            {
                String[] row2 = { palettec.ProductName, $"{palettec.Lot}", $"{palettec.Total}",
                    $"{palettec.Lot*palettec.Total}", $"{palettec.UserId}" };
                dataGridView1.Rows.Add(row2);
                dataGridView1.ClearSelection();

            }
        }
    }
}
