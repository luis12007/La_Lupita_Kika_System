namespace La_Lupita_Kika.Views.Products.Inventario
{
    partial class AddInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInventario));
            type_cbb = new Components.RJComboBox();
            Subsidiary_cbb = new Components.RJComboBox();
            label3 = new Label();
            Category_cbb = new Components.RJComboBox();
            Number_textbox = new Components.RJTextBox();
            Add_button = new Components.RJButton();
            Exit_button = new Button();
            Cat_label = new Label();
            name_label = new Label();
            product_label = new Label();
            Codebar_textbox = new Components.RJTextBox();
            label1 = new Label();
            Name_textbox = new Components.RJTextBox();
            Number_label = new Label();
            label2 = new Label();
            Price_textbox = new Components.RJTextBox();
            SuspendLayout();
            // 
            // type_cbb
            // 
            type_cbb.BackColor = Color.White;
            type_cbb.BorderColor = Color.Silver;
            type_cbb.BorderSize = 1;
            type_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            type_cbb.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            type_cbb.ForeColor = Color.DimGray;
            type_cbb.IconColor = Color.FromArgb(255, 54, 112);
            type_cbb.Items.AddRange(new object[] { "Paleta", "Mangonada", "Helados", "Dulces", "Otros(Snacks)" });
            type_cbb.ListBackColor = Color.FromArgb(230, 228, 245);
            type_cbb.ListTextColor = Color.DimGray;
            type_cbb.Location = new Point(13, 114);
            type_cbb.MinimumSize = new Size(200, 30);
            type_cbb.Name = "type_cbb";
            type_cbb.Padding = new Padding(1);
            type_cbb.Size = new Size(250, 38);
            type_cbb.TabIndex = 1;
            type_cbb.Texts = "Seleccionar";
            type_cbb.OnSelectedIndexChanged += type_cbb_OnSelectedIndexChanged;
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
            Subsidiary_cbb.Location = new Point(13, 583);
            Subsidiary_cbb.MinimumSize = new Size(200, 30);
            Subsidiary_cbb.Name = "Subsidiary_cbb";
            Subsidiary_cbb.Padding = new Padding(1);
            Subsidiary_cbb.Size = new Size(250, 38);
            Subsidiary_cbb.TabIndex = 40;
            Subsidiary_cbb.Texts = "Seleccionar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(13, 546);
            label3.Name = "label3";
            label3.Size = new Size(108, 29);
            label3.TabIndex = 39;
            label3.Text = "Sucursal";
            // 
            // Category_cbb
            // 
            Category_cbb.BackColor = Color.White;
            Category_cbb.BorderColor = Color.Silver;
            Category_cbb.BorderSize = 1;
            Category_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Category_cbb.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Category_cbb.ForeColor = Color.DimGray;
            Category_cbb.IconColor = Color.FromArgb(255, 54, 112);
            Category_cbb.ListBackColor = Color.FromArgb(27, 166, 182);
            Category_cbb.ListTextColor = Color.White;
            Category_cbb.Location = new Point(12, 198);
            Category_cbb.MinimumSize = new Size(200, 30);
            Category_cbb.Name = "Category_cbb";
            Category_cbb.Padding = new Padding(1);
            Category_cbb.Size = new Size(250, 38);
            Category_cbb.TabIndex = 37;
            Category_cbb.Texts = "Seleccionar";
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
            Number_textbox.Location = new Point(13, 391);
            Number_textbox.Margin = new Padding(4);
            Number_textbox.Multiline = false;
            Number_textbox.Name = "Number_textbox";
            Number_textbox.Padding = new Padding(10, 7, 10, 7);
            Number_textbox.PasswordChar = false;
            Number_textbox.PlaceholderColor = Color.DarkGray;
            Number_textbox.PlaceholderText = "#";
            Number_textbox.ReadOnly = false;
            Number_textbox.Size = new Size(99, 35);
            Number_textbox.TabIndex = 36;
            Number_textbox.TextAlign = ContentAlignment.MiddleLeft;
            Number_textbox.Texts = "";
            Number_textbox.UnderlinedStyle = true;
            Number_textbox._TextChanged += Number_textbox__TextChanged;
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
            Add_button.Location = new Point(12, 634);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(265, 96);
            Add_button.TabIndex = 35;
            Add_button.Text = "Agregar";
            Add_button.TextColor = Color.Black;
            Add_button.UseVisualStyleBackColor = false;
            Add_button.Click += Add_button_Click;
            // 
            // Exit_button
            // 
            Exit_button.BackColor = Color.White;
            Exit_button.FlatAppearance.BorderColor = Color.White;
            Exit_button.FlatAppearance.MouseDownBackColor = Color.White;
            Exit_button.FlatAppearance.MouseOverBackColor = Color.White;
            Exit_button.FlatStyle = FlatStyle.Flat;
            Exit_button.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda__2_;
            Exit_button.Location = new Point(12, 12);
            Exit_button.Name = "Exit_button";
            Exit_button.Size = new Size(45, 40);
            Exit_button.TabIndex = 34;
            Exit_button.UseVisualStyleBackColor = false;
            Exit_button.Click += Exit_button_Click;
            // 
            // Cat_label
            // 
            Cat_label.AutoSize = true;
            Cat_label.Font = new Font("Bahnschrift", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Cat_label.Location = new Point(12, 166);
            Cat_label.Name = "Cat_label";
            Cat_label.Size = new Size(117, 29);
            Cat_label.TabIndex = 33;
            Cat_label.Text = "Categoria";
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Bahnschrift", 14F, FontStyle.Regular, GraphicsUnit.Point);
            name_label.Location = new Point(12, 262);
            name_label.Name = "name_label";
            name_label.Size = new Size(100, 29);
            name_label.TabIndex = 31;
            name_label.Text = "Nombre";
            // 
            // product_label
            // 
            product_label.AutoSize = true;
            product_label.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            product_label.Location = new Point(12, 55);
            product_label.Name = "product_label";
            product_label.Size = new Size(270, 41);
            product_label.TabIndex = 30;
            product_label.Text = "Tipo de producto";
            // 
            // Codebar_textbox
            // 
            Codebar_textbox.BackColor = SystemColors.Window;
            Codebar_textbox.BorderColor = Color.Silver;
            Codebar_textbox.BorderFocusColor = Color.FromArgb(255, 54, 112);
            Codebar_textbox.BorderRadius = 0;
            Codebar_textbox.BorderSize = 2;
            Codebar_textbox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Codebar_textbox.ForeColor = Color.Black;
            Codebar_textbox.Location = new Point(13, 484);
            Codebar_textbox.Margin = new Padding(4);
            Codebar_textbox.Multiline = false;
            Codebar_textbox.Name = "Codebar_textbox";
            Codebar_textbox.Padding = new Padding(10, 7, 10, 7);
            Codebar_textbox.PasswordChar = false;
            Codebar_textbox.PlaceholderColor = Color.DarkGray;
            Codebar_textbox.PlaceholderText = "";
            Codebar_textbox.ReadOnly = false;
            Codebar_textbox.Size = new Size(249, 39);
            Codebar_textbox.TabIndex = 42;
            Codebar_textbox.TextAlign = ContentAlignment.MiddleLeft;
            Codebar_textbox.Texts = "";
            Codebar_textbox.UnderlinedStyle = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 451);
            label1.Name = "label1";
            label1.Size = new Size(103, 29);
            label1.TabIndex = 41;
            label1.Text = "Codebar";
            // 
            // Name_textbox
            // 
            Name_textbox.BackColor = SystemColors.Window;
            Name_textbox.BorderColor = Color.Silver;
            Name_textbox.BorderFocusColor = Color.FromArgb(255, 54, 112);
            Name_textbox.BorderRadius = 0;
            Name_textbox.BorderSize = 2;
            Name_textbox.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name_textbox.ForeColor = Color.Black;
            Name_textbox.Location = new Point(13, 295);
            Name_textbox.Margin = new Padding(4);
            Name_textbox.Multiline = false;
            Name_textbox.Name = "Name_textbox";
            Name_textbox.Padding = new Padding(10, 7, 10, 7);
            Name_textbox.PasswordChar = false;
            Name_textbox.PlaceholderColor = Color.DarkGray;
            Name_textbox.PlaceholderText = "";
            Name_textbox.ReadOnly = false;
            Name_textbox.Size = new Size(249, 39);
            Name_textbox.TabIndex = 43;
            Name_textbox.TextAlign = ContentAlignment.MiddleLeft;
            Name_textbox.Texts = "";
            Name_textbox.UnderlinedStyle = true;
            // 
            // Number_label
            // 
            Number_label.AutoSize = true;
            Number_label.Font = new Font("Bahnschrift", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Number_label.Location = new Point(12, 358);
            Number_label.Name = "Number_label";
            Number_label.Size = new Size(107, 29);
            Number_label.TabIndex = 32;
            Number_label.Text = "Cantidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(164, 358);
            label2.Name = "label2";
            label2.Size = new Size(81, 29);
            label2.TabIndex = 44;
            label2.Text = "Precio";
            // 
            // Price_textbox
            // 
            Price_textbox.BackColor = SystemColors.Window;
            Price_textbox.BorderColor = Color.Silver;
            Price_textbox.BorderFocusColor = Color.FromArgb(255, 54, 112);
            Price_textbox.BorderRadius = 0;
            Price_textbox.BorderSize = 2;
            Price_textbox.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            Price_textbox.ForeColor = Color.FromArgb(64, 64, 64);
            Price_textbox.Location = new Point(163, 391);
            Price_textbox.Margin = new Padding(4);
            Price_textbox.Multiline = false;
            Price_textbox.Name = "Price_textbox";
            Price_textbox.Padding = new Padding(10, 7, 10, 7);
            Price_textbox.PasswordChar = false;
            Price_textbox.PlaceholderColor = Color.DarkGray;
            Price_textbox.PlaceholderText = "$";
            Price_textbox.ReadOnly = false;
            Price_textbox.Size = new Size(99, 35);
            Price_textbox.TabIndex = 45;
            Price_textbox.TextAlign = ContentAlignment.MiddleLeft;
            Price_textbox.Texts = "";
            Price_textbox.UnderlinedStyle = true;
            // 
            // AddInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(295, 743);
            Controls.Add(Price_textbox);
            Controls.Add(label2);
            Controls.Add(Name_textbox);
            Controls.Add(Codebar_textbox);
            Controls.Add(label1);
            Controls.Add(Subsidiary_cbb);
            Controls.Add(label3);
            Controls.Add(Category_cbb);
            Controls.Add(Number_textbox);
            Controls.Add(Add_button);
            Controls.Add(Exit_button);
            Controls.Add(Cat_label);
            Controls.Add(Number_label);
            Controls.Add(name_label);
            Controls.Add(product_label);
            Controls.Add(type_cbb);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddInventario";
            Load += AddInventario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Components.RJComboBox type_cbb;
        private Components.RJComboBox Subsidiary_cbb;
        private Label label3;
        private Components.RJComboBox Category_cbb;
        private Components.RJTextBox Number_textbox;
        private Components.RJButton Add_button;
        private Button Exit_button;
        private Label Cat_label;
        private Label name_label;
        private Label product_label;
        private Components.RJTextBox Codebar_textbox;
        private Label label1;
        private Components.RJTextBox Name_textbox;
        private Label Number_label;
        private Label label2;
        private Components.RJTextBox Price_textbox;
    }
}