using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Admin.User
{
    public partial class UserList : Form
    {
        private string ConnectionString;
        public UserList(string connectionString)
        {
            this.ConnectionString = connectionString;
            InitializeComponent();
        }

        private void UserList_Load(object sender, EventArgs e)
        {

        }
    }
}
