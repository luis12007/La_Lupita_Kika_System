namespace La_Lupita_Kika.Views.Ingredients
{
    partial class AddIngredients
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
            Subsidiary_cbb = new Components.RJComboBox();
            label1 = new Label();
            Number_textbox = new Components.RJTextBox();
            Process_button = new Components.RJButton();
            Add_button = new Components.RJButton();
            Exit_button = new Button();
            Products_cbb = new Components.RJComboBox();
            Products_dataGridView = new DataGridView();
            Number_label = new Label();
            product_label = new Label();
            ((System.ComponentModel.ISupportInitialize)Products_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Subsidiary_cbb
            // 
            Subsidiary_cbb.BackColor = Color.White;
            Subsidiary_cbb.BorderColor = Color.Silver;
            Subsidiary_cbb.BorderSize = 1;
            Subsidiary_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Subsidiary_cbb.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Subsidiary_cbb.ForeColor = Color.DimGray;
            Subsidiary_cbb.IconColor = Color.FromArgb(255, 54, 112);
            Subsidiary_cbb.Items.AddRange(new object[] { "Paletas", "Mangoneadas", "Helados", "Dulces", "Otros(snacks)" });
            Subsidiary_cbb.ListBackColor = Color.FromArgb(27, 166, 182);
            Subsidiary_cbb.ListTextColor = Color.White;
            Subsidiary_cbb.Location = new Point(9, 293);
            Subsidiary_cbb.MinimumSize = new Size(200, 30);
            Subsidiary_cbb.Name = "Subsidiary_cbb";
            Subsidiary_cbb.Padding = new Padding(1);
            Subsidiary_cbb.Size = new Size(250, 38);
            Subsidiary_cbb.TabIndex = 43;
            Subsidiary_cbb.Texts = "Seleccionar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(9, 256);
            label1.Name = "label1";
            label1.Size = new Size(108, 29);
            label1.TabIndex = 42;
            label1.Text = "Sucursal";
            // 
            // Number_textbox
            // 
            Number_textbox.BackColor = SystemColors.Window;
            Number_textbox.BorderColor = Color.Silver;
            Number_textbox.BorderFocusColor = Color.FromArgb(255, 54, 112);
            Number_textbox.BorderRadius = 0;
            Number_textbox.BorderSize = 2;
            Number_textbox.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            Number_textbox.ForeColor = Color.FromArgb(64, 64, 64);
            Number_textbox.Location = new Point(10, 198);
            Number_textbox.Margin = new Padding(4);
            Number_textbox.Multiline = false;
            Number_textbox.Name = "Number_textbox";
            Number_textbox.Padding = new Padding(10, 7, 10, 7);
            Number_textbox.PasswordChar = false;
            Number_textbox.PlaceholderColor = Color.DarkGray;
            Number_textbox.PlaceholderText = "#";
            Number_textbox.ReadOnly = false;
            Number_textbox.Size = new Size(78, 35);
            Number_textbox.TabIndex = 39;
            Number_textbox.TextAlign = ContentAlignment.MiddleLeft;
            Number_textbox.Texts = "";
            Number_textbox.UnderlinedStyle = false;
            // 
            // Process_button
            // 
            Process_button.BackColor = Color.White;
            Process_button.BackgroundColor = Color.White;
            Process_button.BorderColor = Color.FromArgb(255, 54, 112);
            Process_button.BorderRadius = 20;
            Process_button.BorderSize = 2;
            Process_button.FlatAppearance.BorderSize = 0;
            Process_button.FlatStyle = FlatStyle.Flat;
            Process_button.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Process_button.ForeColor = Color.Black;
            Process_button.Location = new Point(604, 615);
            Process_button.Name = "Process_button";
            Process_button.Size = new Size(254, 86);
            Process_button.TabIndex = 38;
            Process_button.Text = "Procesar";
            Process_button.TextColor = Color.Black;
            Process_button.UseVisualStyleBackColor = false;
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
            Add_button.Location = new Point(8, 350);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(265, 139);
            Add_button.TabIndex = 37;
            Add_button.Text = "Agregar";
            Add_button.TextColor = Color.Black;
            Add_button.UseVisualStyleBackColor = false;
            // 
            // Exit_button
            // 
            Exit_button.BackColor = Color.White;
            Exit_button.FlatAppearance.BorderColor = Color.White;
            Exit_button.FlatAppearance.MouseDownBackColor = Color.White;
            Exit_button.FlatAppearance.MouseOverBackColor = Color.White;
            Exit_button.FlatStyle = FlatStyle.Flat;
            Exit_button.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda__2_;
            Exit_button.Location = new Point(8, 12);
            Exit_button.Name = "Exit_button";
            Exit_button.Size = new Size(45, 40);
            Exit_button.TabIndex = 36;
            Exit_button.UseVisualStyleBackColor = false;
            // 
            // Products_cbb
            // 
            Products_cbb.BackColor = Color.White;
            Products_cbb.BorderColor = Color.Silver;
            Products_cbb.BorderSize = 1;
            Products_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Products_cbb.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Products_cbb.ForeColor = Color.DimGray;
            Products_cbb.IconColor = Color.FromArgb(255, 54, 112);
            Products_cbb.Items.AddRange(new object[] { "Paletas", "Mangoneadas", "Helados", "Dulces", "Otros(snacks)" });
            Products_cbb.ListBackColor = Color.FromArgb(27, 166, 182);
            Products_cbb.ListTextColor = Color.White;
            Products_cbb.Location = new Point(8, 102);
            Products_cbb.MinimumSize = new Size(200, 30);
            Products_cbb.Name = "Products_cbb";
            Products_cbb.Padding = new Padding(1);
            Products_cbb.Size = new Size(250, 38);
            Products_cbb.TabIndex = 35;
            Products_cbb.Texts = "Paletas";
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
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 204, 204);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Products_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            Products_dataGridView.EnableHeadersVisualStyles = false;
            Products_dataGridView.GridColor = Color.Black;
            Products_dataGridView.Location = new Point(310, 12);
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
            Products_dataGridView.Size = new Size(879, 597);
            Products_dataGridView.TabIndex = 33;
            // 
            // Number_label
            // 
            Number_label.AutoSize = true;
            Number_label.Font = new Font("Bahnschrift", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Number_label.Location = new Point(9, 165);
            Number_label.Name = "Number_label";
            Number_label.Size = new Size(107, 29);
            Number_label.TabIndex = 32;
            Number_label.Text = "Cantidad";
            // 
            // product_label
            // 
            product_label.AutoSize = true;
            product_label.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            product_label.Location = new Point(8, 55);
            product_label.Name = "product_label";
            product_label.Size = new Size(306, 41);
            product_label.TabIndex = 30;
            product_label.Text = "Tipo de Ingrediente";
            // 
            // AddIngredients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1198, 718);
            Controls.Add(Subsidiary_cbb);
            Controls.Add(label1);
            Controls.Add(Number_textbox);
            Controls.Add(Process_button);
            Controls.Add(Add_button);
            Controls.Add(Exit_button);
            Controls.Add(Products_cbb);
            Controls.Add(Products_dataGridView);
            Controls.Add(Number_label);
            Controls.Add(product_label);
            Name = "AddIngredients";
            Text = "AddIngredients";
            ((System.ComponentModel.ISupportInitialize)Products_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Components.RJComboBox Subsidiary_cbb;
        private Label label1;
        private Components.RJTextBox Number_textbox;
        private Components.RJButton Process_button;
        private Components.RJButton Add_button;
        private Button Exit_button;
        private Components.RJComboBox Products_cbb;
        private DataGridView Products_dataGridView;
        private Label Number_label;
        private Label product_label;
    }
}