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
    public partial class Warning : Form
    {
        private string ConnectionString;
        public Warning(string connectionString)
        {
            this.ConnectionString = connectionString;
            InitializeComponent();
        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}
