﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Ingredients
{
    public partial class Ingredients : Form
    {
        private string ConnectionString;
        public Ingredients(string connectionString)
        {
            this.ConnectionString = connectionString;
            InitializeComponent();
        }
    }
}
