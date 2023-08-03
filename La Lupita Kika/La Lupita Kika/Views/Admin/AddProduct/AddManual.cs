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

namespace La_Lupita_Kika.Views.Admin.AddProduct
{
    public partial class AddManual : Form
    {
        private string ConnectionString;
        private CandyRepository candysrepo;
        private OtherRepository otherrepo;
        public AddManual(string connectionString)
        {
            this.ConnectionString = connectionString;
            InitializeComponent();
            this.candysrepo = new CandyRepository(connectionString);
            this.otherrepo = new OtherRepository(connectionString);
        }

        private void AddManual_Load(object sender, EventArgs e)
        {

        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            string product = Products_cbb.Texts;
            if (rjTextBox1.Texts == ""
                || rjTextBox3.Texts == ""
                || rjTextBox4.Texts == "")
            {
                return;
            }

            switch (product)
            {
                case "dulce":

                    break;
                case "otro":

                    break;

                default:
                    MessageBox.Show("Error contacte a soporte");
                    break;
            }

            MessageBox.Show("Agregado correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
