using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using La_Lupita_Kika.Views.Components;
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

namespace La_Lupita_Kika.Views.Staff
{
    public partial class CashOutdit : Form
    {
        private string connectionString;
        private int thisregis;
        private RegisterXSalesRepository registerrepo;
        private SalesRepository salesrepo;
        private RegisterRepository regisrepo;
        private float daygains;
        private int subsidiaryid;


        private List<SalesWithRegisterData> registrosEncontrados = new List<SalesWithRegisterData>();
        private List<Models.Products> ProductosListCashOut = new List<Models.Products>(); // Lista de productos corte

        public CashOutdit(string connectionString, int thisregis, int subsidiary, List<Models.Products> productosListCashOut)
        {
            this.connectionString = connectionString;
            this.thisregis = thisregis;
            this.registerrepo = new RegisterXSalesRepository(connectionString);
            this.salesrepo = new SalesRepository(connectionString);
            this.regisrepo = new RegisterRepository(connectionString);
            this.ProductosListCashOut = productosListCashOut;
            this.subsidiaryid = subsidiary;
            InitializeComponent();
        }

        private void CashOutdit_Load(object sender, EventArgs e)
        {
            registrosEncontrados.Clear();

            /*DateTime startDate = regisrepo.GetInhourById(thisregis);
            DateTime endDate = DateTime.Now;
            registrosEncontrados = regisrepo.GetSalesWithRegisterDataByDateRange(startDate, endDate, subsidiaryid);*/
            float totalSum = 0.0f; // Variable para guardar la suma total

            foreach (var sale in ProductosListCashOut)
            {
                float saleTotal = sale.Cantidad * sale.Valor;
                totalSum += saleTotal;
            }

            totalSum = (float)Math.Round(totalSum, 2);
            day_textbox.Texts = totalSum.ToString();
            daygains = totalSum;
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {

        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void Report_button_Click(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            string url = "https://wa.link/q9jg7x";

            try
            {
                Process.Start("cmd", $"/c start {url}");
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al abrir el enlace
                Console.WriteLine("No se pudo abrir el enlace: " + ex.Message);
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (day_textbox.Texts == "" || caja_textbox.Texts == "")
            {
                MessageBox.Show("Campos Vacios.");
                return;
            }
            float verify = float.Parse(day_textbox.Texts);
            float caja = float.Parse(caja_textbox.Texts);
            if (verify - caja > 0)
            {
                MessageBox.Show("Reportar incongruencia. ");
            }
            TimeSpan outhour = DateTime.Now.TimeOfDay;
            regisrepo.UpdateOuthourById(thisregis, outhour);
            regisrepo.UpdateDayGainsById(thisregis, daygains);

            //-------------------------------------------------------------------------
            foreach (var producto in ProductosListCashOut)
                {
                    


                    int registers = thisregis;
                    // Obtener los datos de cada producto en la lista
                    string nombre = producto.Nombre;
                    float cantidad = producto.Cantidad;
                    float precio = producto.Valor;


                    // Llamar al método Add del repositorio SalesRepository para guardar los datos en la base de datos
                    Sales sales = new Sales(nombre, cantidad, precio);
                    salesrepo.Add(sales);


                    List<Sales> salesList = salesrepo.GetAll();
                    Sales foundSales = salesList.Find(sales => sales.Name.Equals(nombre) && sales.Lot.Equals(cantidad));

                    // Obtener el ID del objeto Sales encontrado
                    int foundId = foundSales != null ? foundSales.Id : -1;

                    if (foundId != -1)
                    {
                        Registerxsales register = new Registerxsales(registers, foundId);
                        registerrepo.Add(register);
                    }


                }

            //-------------------------------------------------------------------------
            this.DialogResult = DialogResult.OK;
            Application.Exit();
        }
    }
}
