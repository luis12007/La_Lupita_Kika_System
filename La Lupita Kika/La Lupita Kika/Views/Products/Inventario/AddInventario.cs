using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Products.Inventario
{
    public partial class AddInventario : Form
    {
        private string Conection;
        public AddInventario(string connection)
        {
            this.Conection = connection;
            InitializeComponent();
        }

        private void AddInventario_Load(object sender, EventArgs e)
        {

        }
    }
}
