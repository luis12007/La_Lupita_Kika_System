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
        public Gains(string connectionString)
        {
            this.ConnectionString = connectionString;
            InitializeComponent();
        }
    }
}
