using La_Lupita_Kika.Views.Admin.AddProduct;
using La_Lupita_Kika.Views.Admin.User;
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
    public partial class Home : Form
    {

        private string connectionString;

        public Home(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();

            // Abrir el nuevo formulario de facturación
            Login formFacturation = new Login(connectionString);
            formFacturation.ShowDialog();

            Application.Exit();

        }

        private void Palletes_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            Products.Palettes.Inventario formFacturation = new Products.Palettes.Inventario(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Add_button_MouseHover(object sender, EventArgs e)
        {
        }

        private void Users_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            UserList formFacturation = new UserList(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            AddProducts formFacturation = new AddProducts(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Alert_Button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            Warning formFacturation = new Warning(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Gains_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            Gains formFacturation = new Gains(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Ingredients_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            Ingredients.Ingredients formFacturation = new Ingredients.Ingredients(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }
    }
}
