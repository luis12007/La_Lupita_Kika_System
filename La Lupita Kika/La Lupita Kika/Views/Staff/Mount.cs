using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Staff
{
    public partial class Mount : Form
    {
        private string connectionString;
        private float moneyChange;
        private float mounts;
        private float mountstext;
        private List<Models.Products> productosList = new List<Models.Products>(); // Lista de productos
        private int thisregis;
        public Mount(String connectionString, float mount, List<Models.Products> productosList, int thisregis)
        {
            this.thisregis = thisregis;
            this.connectionString = connectionString;
            this.mounts = mount;
            InitializeComponent();
            this.productosList = productosList;
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void Mount_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {

            if (textBox.Texts != "")
            {
                mountstext = float.Parse(textBox.Texts);
                moneyChange = mountstext - mounts;

                if (moneyChange < 0)
                {
                    MessageBox.Show("Ingrese un numero mayor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                this.Close();

                float money = (float)Math.Round(moneyChange, 3);
                // Abrir el nuevo formulario de facturación
                Staff.change formFacturation = new Staff.change(connectionString, money, productosList, thisregis, mountstext, mounts);
                formFacturation.ShowDialog();
            }
            else
            {
                MessageBox.Show("Campos vacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox__TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al evento Login_button_Click
                button_Click(sender, e);
            }
        }
    }
}
