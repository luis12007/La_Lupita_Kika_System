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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            button1 = new Button();
            Products_dataGridView = new DataGridView();
            rjButton1 = new Components.RJButton();
            Add_button = new Components.RJButton();
            Products_cbb = new Components.RJComboBox();
            subsidiary_cbb = new Components.RJComboBox();
            Find = new Components.RJTextBox();
            button2 = new Button();
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            Products_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            Products_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(152, 153, 182);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            Products_dataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            Products_dataGridView.EnableHeadersVisualStyles = false;
            Products_dataGridView.GridColor = Color.Black;
            Products_dataGridView.Location = new Point(12, 102);
            Products_dataGridView.Name = "Products_dataGridView";
            Products_dataGridView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 98, 133);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            Products_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            Products_dataGridView.RowHeadersVisible = false;
            Products_dataGridView.RowHeadersWidth = 51;
            Products_dataGridView.RowTemplate.Height = 29;
            Products_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Products_dataGridView.Size = new Size(1010, 387);
            Products_dataGridView.TabIndex = 19;
            Products_dataGridView.CellContentClick += Products_dataGridView_CellContentClick;
            Products_dataGridView.CellDoubleClick += Products_dataGridView_CellDoubleClick;
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
            // Products_cbb
            // 
            Products_cbb.BackColor = Color.WhiteSmoke;
            Products_cbb.BorderColor = Color.MediumSlateBlue;
            Products_cbb.BorderSize = 1;
            Products_cbb.DropDownStyle = ComboBoxStyle.DropDown;
            Products_cbb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Products_cbb.ForeColor = Color.DimGray;
            Products_cbb.IconColor = Color.MediumSlateBlue;
            Products_cbb.Items.AddRange(new object[] { "Paletas", "Mangoneadas", "Helados", "Dulces", "Otros(snacks)" });
            Products_cbb.ListBackColor = Color.FromArgb(230, 228, 245);
            Products_cbb.ListTextColor = Color.DimGray;
            Products_cbb.Location = new Point(12, 58);
            Products_cbb.MinimumSize = new Size(200, 30);
            Products_cbb.Name = "Products_cbb";
            Products_cbb.Padding = new Padding(1);
            Products_cbb.Size = new Size(250, 38);
            Products_cbb.TabIndex = 26;
            Products_cbb.Texts = "";
            Products_cbb.OnSelectedIndexChanged += Products_cbb_OnSelectedIndexChanged;
            // 
            // subsidiary_cbb
            // 
            subsidiary_cbb.BackColor = Color.WhiteSmoke;
            subsidiary_cbb.BorderColor = Color.MediumSlateBlue;
            subsidiary_cbb.BorderSize = 1;
            subsidiary_cbb.DropDownStyle = ComboBoxStyle.DropDown;
            subsidiary_cbb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            subsidiary_cbb.ForeColor = Color.DimGray;
            subsidiary_cbb.IconColor = Color.MediumSlateBlue;
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
            Find.BorderColor = Color.MediumSlateBlue;
            Find.BorderFocusColor = Color.HotPink;
            Find.BorderRadius = 0;
            Find.BorderSize = 2;
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
            Find.Size = new Size(312, 35);
            Find.TabIndex = 28;
            Find.TextAlign = ContentAlignment.MiddleLeft;
            Find.Texts = "";
            Find.UnderlinedStyle = false;
            Find._TextChanged += Find__TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(844, 58);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 29;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
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
        private Components.RJButton rjButton1;
        private DataGridView Products_dataGridView;
        private Components.RJComboBox Products_cbb;
        private Components.RJComboBox subsidiary_cbb;
        private Components.RJTextBox Find;
        private Button button2;
    }
}