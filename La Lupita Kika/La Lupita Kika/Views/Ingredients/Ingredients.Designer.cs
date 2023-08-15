namespace La_Lupita_Kika.Views.Ingredients
{
    partial class Ingredients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingredients));
            Ingredients_dataGridView = new DataGridView();
            button1 = new Button();
            Add_button = new Components.RJButton();
            button2 = new Button();
            Find = new Components.RJTextBox();
            Subsidiary_cbb = new Components.RJComboBox();
            Add_Products = new Components.RJButton();
            ((System.ComponentModel.ISupportInitialize)Ingredients_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Ingredients_dataGridView
            // 
            Ingredients_dataGridView.AllowUserToDeleteRows = false;
            Ingredients_dataGridView.AllowUserToResizeColumns = false;
            Ingredients_dataGridView.AllowUserToResizeRows = false;
            Ingredients_dataGridView.BackgroundColor = Color.White;
            Ingredients_dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Ingredients_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Ingredients_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(152, 153, 182);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Ingredients_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            Ingredients_dataGridView.EnableHeadersVisualStyles = false;
            Ingredients_dataGridView.GridColor = Color.Black;
            Ingredients_dataGridView.Location = new Point(12, 98);
            Ingredients_dataGridView.Name = "Ingredients_dataGridView";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 98, 133);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Ingredients_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            Ingredients_dataGridView.RowHeadersVisible = false;
            Ingredients_dataGridView.RowHeadersWidth = 51;
            Ingredients_dataGridView.RowTemplate.Height = 29;
            Ingredients_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Ingredients_dataGridView.Size = new Size(1126, 387);
            Ingredients_dataGridView.TabIndex = 20;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda__2_;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(45, 40);
            button1.TabIndex = 21;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Add_button
            // 
            Add_button.BackColor = Color.White;
            Add_button.BackgroundColor = Color.White;
            Add_button.BorderColor = Color.FromArgb(255, 54, 112);
            Add_button.BorderRadius = 20;
            Add_button.BorderSize = 2;
            Add_button.FlatAppearance.BorderSize = 0;
            Add_button.FlatStyle = FlatStyle.Flat;
            Add_button.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Add_button.ForeColor = Color.Black;
            Add_button.Location = new Point(459, 491);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(273, 72);
            Add_button.TabIndex = 22;
            Add_button.Text = "Procesar";
            Add_button.TextColor = Color.Black;
            Add_button.UseVisualStyleBackColor = false;
            Add_button.Click += Add_button_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.buscar;
            button2.Location = new Point(1066, 54);
            button2.Name = "button2";
            button2.Size = new Size(70, 35);
            button2.TabIndex = 33;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Find
            // 
            Find.BackColor = SystemColors.Window;
            Find.BorderColor = Color.FromArgb(255, 54, 112);
            Find.BorderFocusColor = Color.HotPink;
            Find.BorderRadius = 20;
            Find.BorderSize = 1;
            Find.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            Find.ForeColor = Color.FromArgb(64, 64, 64);
            Find.Location = new Point(639, 54);
            Find.Margin = new Padding(4);
            Find.Multiline = false;
            Find.Name = "Find";
            Find.Padding = new Padding(10, 7, 10, 7);
            Find.PasswordChar = false;
            Find.PlaceholderColor = Color.DarkGray;
            Find.PlaceholderText = "";
            Find.ReadOnly = false;
            Find.Size = new Size(420, 35);
            Find.TabIndex = 32;
            Find.TextAlign = ContentAlignment.MiddleLeft;
            Find.Texts = "";
            Find.UnderlinedStyle = false;
            // 
            // Subsidiary_cbb
            // 
            Subsidiary_cbb.BackColor = Color.White;
            Subsidiary_cbb.BorderColor = Color.Silver;
            Subsidiary_cbb.BorderSize = 1;
            Subsidiary_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Subsidiary_cbb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Subsidiary_cbb.ForeColor = Color.DimGray;
            Subsidiary_cbb.IconColor = Color.FromArgb(255, 54, 112);
            Subsidiary_cbb.Items.AddRange(new object[] { "Paletas", "Mangoneadas", "Helados", "Dulces", "Otros(snacks)" });
            Subsidiary_cbb.ListBackColor = Color.FromArgb(230, 228, 245);
            Subsidiary_cbb.ListTextColor = Color.DimGray;
            Subsidiary_cbb.Location = new Point(11, 54);
            Subsidiary_cbb.MinimumSize = new Size(200, 30);
            Subsidiary_cbb.Name = "Subsidiary_cbb";
            Subsidiary_cbb.Padding = new Padding(1);
            Subsidiary_cbb.Size = new Size(250, 38);
            Subsidiary_cbb.TabIndex = 30;
            Subsidiary_cbb.Texts = "";
            Subsidiary_cbb.OnSelectedIndexChanged += Subsidiary_cbb_OnSelectedIndexChanged;
            // 
            // Add_Products
            // 
            Add_Products.BackColor = Color.White;
            Add_Products.BackgroundColor = Color.White;
            Add_Products.BorderColor = Color.FromArgb(255, 54, 112);
            Add_Products.BorderRadius = 20;
            Add_Products.BorderSize = 2;
            Add_Products.FlatAppearance.BorderSize = 0;
            Add_Products.FlatStyle = FlatStyle.Flat;
            Add_Products.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Add_Products.ForeColor = Color.Black;
            Add_Products.Image = Properties.Resources.boton_agregar;
            Add_Products.Location = new Point(1062, 520);
            Add_Products.Name = "Add_Products";
            Add_Products.Size = new Size(76, 43);
            Add_Products.TabIndex = 34;
            Add_Products.TextColor = Color.Black;
            Add_Products.UseVisualStyleBackColor = false;
            Add_Products.Click += rjButton2_Click;
            // 
            // Ingredients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1152, 575);
            Controls.Add(Add_Products);
            Controls.Add(button2);
            Controls.Add(Find);
            Controls.Add(Subsidiary_cbb);
            Controls.Add(Add_button);
            Controls.Add(button1);
            Controls.Add(Ingredients_dataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Ingredients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingredients";
            Load += Ingredients_Load;
            ((System.ComponentModel.ISupportInitialize)Ingredients_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView Ingredients_dataGridView;
        private Button button1;
        private Components.RJButton rjButton1;
        private Components.RJButton Add_button;
        private Button button2;
        private Components.RJTextBox rjTextBox1;
        private Components.RJComboBox rjComboBox2;
        private Components.RJComboBox rjComboBox1;
        private Components.RJTextBox Find;
        private Components.RJComboBox subsidiary_cbb;
        private Components.RJComboBox Subsidiary_cbb;
        private Components.RJButton Add_Products;
    }
}