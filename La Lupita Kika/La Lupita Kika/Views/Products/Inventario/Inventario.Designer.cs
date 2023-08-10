namespace La_Lupita_Kika.Views.Products.Palettes
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            button1 = new Button();
            Products_dataGridView = new DataGridView();
            Add_button = new Components.RJButton();
            subsidiary_cbb = new Components.RJComboBox();
            Find = new Components.RJTextBox();
            button2 = new Button();
            Products_cbb = new Components.RJComboBox();
            rjButton1 = new Components.RJButton();
            ((System.ComponentModel.ISupportInitialize)Products_dataGridView).BeginInit();
            SuspendLayout();
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
            button1.TabIndex = 18;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Products_dataGridView
            // 
            Products_dataGridView.AllowUserToAddRows = false;
            Products_dataGridView.AllowUserToDeleteRows = false;
            Products_dataGridView.AllowUserToResizeColumns = false;
            Products_dataGridView.AllowUserToResizeRows = false;
            Products_dataGridView.BackgroundColor = Color.White;
            Products_dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Products_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Products_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(152, 153, 182);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Products_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            Products_dataGridView.EnableHeadersVisualStyles = false;
            Products_dataGridView.GridColor = Color.Black;
            Products_dataGridView.Location = new Point(12, 102);
            Products_dataGridView.Name = "Products_dataGridView";
            Products_dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 98, 133);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Products_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            Products_dataGridView.RowHeadersVisible = false;
            Products_dataGridView.RowHeadersWidth = 51;
            Products_dataGridView.RowTemplate.Height = 29;
            Products_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Products_dataGridView.Size = new Size(1010, 387);
            Products_dataGridView.TabIndex = 19;
            Products_dataGridView.CellContentClick += Products_dataGridView_CellContentClick;
            Products_dataGridView.CellDoubleClick += Products_dataGridView_CellDoubleClick;
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
            Add_button.Location = new Point(12, 502);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(240, 68);
            Add_button.TabIndex = 24;
            Add_button.Text = "Agregar";
            Add_button.TextColor = Color.Black;
            Add_button.UseVisualStyleBackColor = false;
            Add_button.Click += Add_button_Click;
            // 
            // subsidiary_cbb
            // 
            subsidiary_cbb.BackColor = Color.White;
            subsidiary_cbb.BorderColor = Color.Silver;
            subsidiary_cbb.BorderSize = 1;
            subsidiary_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            subsidiary_cbb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            subsidiary_cbb.ForeColor = Color.DimGray;
            subsidiary_cbb.IconColor = Color.FromArgb(255, 54, 112);
            subsidiary_cbb.ListBackColor = Color.FromArgb(230, 228, 245);
            subsidiary_cbb.ListTextColor = Color.DimGray;
            subsidiary_cbb.Location = new Point(268, 58);
            subsidiary_cbb.MinimumSize = new Size(200, 30);
            subsidiary_cbb.Name = "subsidiary_cbb";
            subsidiary_cbb.Padding = new Padding(1);
            subsidiary_cbb.Size = new Size(250, 38);
            subsidiary_cbb.TabIndex = 27;
            subsidiary_cbb.Texts = "";
            subsidiary_cbb.OnSelectedIndexChanged += subsidiary_cbb_OnSelectedIndexChanged;
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
            Find.Location = new Point(525, 58);
            Find.Margin = new Padding(4);
            Find.Multiline = false;
            Find.Name = "Find";
            Find.Padding = new Padding(10, 7, 10, 7);
            Find.PasswordChar = false;
            Find.PlaceholderColor = Color.DarkGray;
            Find.PlaceholderText = "";
            Find.ReadOnly = false;
            Find.Size = new Size(420, 35);
            Find.TabIndex = 28;
            Find.TextAlign = ContentAlignment.MiddleLeft;
            Find.Texts = "";
            Find.UnderlinedStyle = false;
            Find._TextChanged += Find__TextChanged;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.buscar;
            button2.Location = new Point(952, 58);
            button2.Name = "button2";
            button2.Size = new Size(70, 35);
            button2.TabIndex = 29;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Products_cbb
            // 
            Products_cbb.BackColor = Color.White;
            Products_cbb.BorderColor = Color.Silver;
            Products_cbb.BorderSize = 1;
            Products_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Products_cbb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Products_cbb.ForeColor = Color.DimGray;
            Products_cbb.IconColor = Color.FromArgb(255, 54, 112);
            Products_cbb.Items.AddRange(new object[] { "Paletas", "Mangoneadas", "Helados", "Dulces", "Otros(snacks)" });
            Products_cbb.ListBackColor = Color.FromArgb(230, 228, 245);
            Products_cbb.ListTextColor = Color.DimGray;
            Products_cbb.Location = new Point(12, 58);
            Products_cbb.MinimumSize = new Size(200, 30);
            Products_cbb.Name = "Products_cbb";
            Products_cbb.Padding = new Padding(1);
            Products_cbb.Size = new Size(250, 38);
            Products_cbb.TabIndex = 26;
            Products_cbb.Texts = "Paletas";
            Products_cbb.OnSelectedIndexChanged += Products_cbb_OnSelectedIndexChanged;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.White;
            rjButton1.BackgroundColor = Color.White;
            rjButton1.BorderColor = Color.Green;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 2;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Location = new Point(782, 502);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(240, 68);
            rjButton1.TabIndex = 25;
            rjButton1.Text = "Excel";
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1034, 589);
            Controls.Add(button2);
            Controls.Add(Find);
            Controls.Add(subsidiary_cbb);
            Controls.Add(Products_cbb);
            Controls.Add(rjButton1);
            Controls.Add(Add_button);
            Controls.Add(Products_dataGridView);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Inventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Palettes";
            Load += Inventario_Load;
            ((System.ComponentModel.ISupportInitialize)Products_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Components.RJButton Add_button;
        private DataGridView Products_dataGridView;
        private Components.RJComboBox subsidiary_cbb;
        private Components.RJTextBox Find;
        private Button button2;
        private Components.RJComboBox Products_cbb;
        private Components.RJButton rjButton1;
    }
}