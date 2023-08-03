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
        public CashOutdit(string connectionString, int thisregis)
        {
            this.connectionString = connectionString;
            this.thisregis = thisregis;
            this.registerrepo = new RegisterXSalesRepository(connectionString);
            this.salesrepo = new SalesRepository(connectionString);
            this.regisrepo = new RegisterRepository(connectionString);
            InitializeComponent();
        }

        private void CashOutdit_Load(object sender, EventArgs e)
        {
            List<Registerxsales> fullList = registerrepo.GetAllByRegisterId(thisregis);
            // Obtener la lista de IDs de ventas asociadas al registro
            List<int> salesIds = fullList.Select(r => r.Sales_id).ToList();

            // Llamar al método GetAllByIds con la lista de IDs de ventas
            List<Sales> salesList = salesrepo.GetAllByIds(salesIds);

            float totalSum = 0.0f; // Variable para guardar la suma total

            // Recorrer la lista de Sales y sumar el resultado de multiplicar lot con total para cada objeto
            foreach (var sale in salesList)
            {
                float saleTotal = sale.Lot * sale.Total;
                totalSum += saleTotal;
            }


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

            this.DialogResult = DialogResult.OK;
            Application.Exit();
        }
    }
}
