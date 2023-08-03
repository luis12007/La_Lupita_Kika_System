namespace La_Lupita_Kika.Views.Products.Inventario
{
    partial class EditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProduct));
            CodeBar_textBox = new Components.RJTextBox();
            Price_textbox = new Components.RJTextBox();
            NameUser_textBox = new Components.RJTextBox();
            Edit_button = new Components.RJButton();
            Exit_button = new Button();
            Cuantity_texbox = new Components.RJTextBox();
            SuspendLayout();
            // 
            // CodeBar_textBox
            // 
            CodeBar_textBox.BackColor = SystemColors.Window;
            CodeBar_textBox.BorderColor = Color.FromArgb(255, 54, 112);
            CodeBar_textBox.BorderFocusColor = Color.HotPink;
            CodeBar_textBox.BorderRadius = 5;
            CodeBar_textBox.BorderSize = 2;
            CodeBar_textBox.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            CodeBar_textBox.ForeColor = Color.FromArgb(64, 64, 64);
            CodeBar_textBox.Location = new Point(13, 184);
            CodeBar_textBox.Margin = new Padding(4);
            CodeBar_textBox.Multiline = false;
            CodeBar_textBox.Name = "CodeBar_textBox";
            CodeBar_textBox.Padding = new Padding(10, 7, 10, 7);
            CodeBar_textBox.PasswordChar = false;
            CodeBar_textBox.PlaceholderColor = Color.DarkGray;
            CodeBar_textBox.PlaceholderText = "";
            CodeBar_textBox.ReadOnly = false;
            CodeBar_textBox.Size = new Size(312, 45);
            CodeBar_textBox.TabIndex = 41;
            CodeBar_textBox.TextAlign = ContentAlignment.MiddleLeft;
            CodeBar_textBox.Texts = "";
            CodeBar_textBox.UnderlinedStyle = true;
            // 
            // Price_textbox
            // 
            Price_textbox.BackColor = SystemColors.Window;
            Price_textbox.BorderColor = Color.FromArgb(255, 54, 112);
            Price_textbox.BorderFocusColor = Color.HotPink;
            Price_textbox.BorderRadius = 5;
            Price_textbox.BorderSize = 2;
            Price_textbox.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Price_textbox.ForeColor = Color.FromArgb(64, 64, 64);
            Price_textbox.Location = new Point(13, 121);
            Price_textbox.Margin = new Padding(4);
            Price_textbox.Multiline = false;
            Price_textbox.Name = "Price_textbox";
            Price_textbox.Padding = new Padding(10, 7, 10, 7);
            Price_textbox.PasswordChar = false;
            Price_textbox.PlaceholderColor = Color.DarkGray;
            Price_textbox.PlaceholderText = "";
            Price_textbox.ReadOnly = false;
            Price_textbox.Size = new Size(312, 45);
            Price_textbox.TabIndex = 40;
            Price_textbox.TextAlign = ContentAlignment.MiddleLeft;
            Price_textbox.Texts = "";
            Price_textbox.UnderlinedStyle = true;
            // 
            // NameUser_textBox
            // 
            NameUser_textBox.BackColor = SystemColors.Window;
            NameUser_textBox.BorderColor = Color.FromArgb(255, 54, 112);
            NameUser_textBox.BorderFocusColor = Color.HotPink;
            NameUser_textBox.BorderRadius = 5;
            NameUser_textBox.BorderSize = 2;
            NameUser_textBox.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            NameUser_textBox.ForeColor = Color.FromArgb(64, 64, 64);
            NameUser_textBox.Location = new Point(13, 59);
            NameUser_textBox.Margin = new Padding(4);
            NameUser_textBox.Multiline = false;
            NameUser_textBox.Name = "NameUser_textBox";
            NameUser_textBox.Padding = new Padding(10, 7, 10, 7);
            NameUser_textBox.PasswordChar = false;
            NameUser_textBox.PlaceholderColor = Color.DarkGray;
            NameUser_textBox.PlaceholderText = "";
            NameUser_textBox.ReadOnly = false;
            NameUser_textBox.Size = new Size(312, 45);
            NameUser_textBox.TabIndex = 39;
            NameUser_textBox.TextAlign = ContentAlignment.MiddleLeft;
            NameUser_textBox.Texts = "";
            NameUser_textBox.UnderlinedStyle = true;
            // 
            // Edit_button
            // 
            Edit_button.BackColor = Color.White;
            Edit_button.BackgroundColor = Color.White;
            Edit_button.BorderColor = Color.FromArgb(255, 54, 112);
            Edit_button.BorderRadius = 20;
            Edit_button.BorderSize = 2;
            Edit_button.FlatAppearance.BorderSize = 0;
            Edit_button.FlatStyle = FlatStyle.Flat;
            Edit_button.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Edit_button.ForeColor = Color.Black;
            Edit_button.Location = new Point(36, 320);
            Edit_button.Name = "Edit_button";
            Edit_button.Size = new Size(250, 118);
            Edit_button.TabIndex = 38;
            Edit_button.Text = "Editar";
            Edit_button.TextColor = Color.Black;
            Edit_button.UseVisualStyleBackColor = false;
            Edit_button.Click += Edit_button_Click;
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
            Exit_button.TabIndex = 37;
            Exit_button.UseVisualStyleBackColor = false;
            Exit_button.Click += Exit_button_Click;
            // 
            // Cuantity_texbox
            // 
            Cuantity_texbox.BackColor = SystemColors.Window;
            Cuantity_texbox.BorderColor = Color.FromArgb(255, 54, 112);
            Cuantity_texbox.BorderFocusColor = Color.HotPink;
            Cuantity_texbox.BorderRadius = 5;
            Cuantity_texbox.BorderSize = 2;
            Cuantity_texbox.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Cuantity_texbox.ForeColor = Color.FromArgb(64, 64, 64);
            Cuantity_texbox.Location = new Point(12, 246);
            Cuantity_texbox.Margin = new Padding(4);
            Cuantity_texbox.Multiline = false;
            Cuantity_texbox.Name = "Cuantity_texbox";
            Cuantity_texbox.Padding = new Padding(10, 7, 10, 7);
            Cuantity_texbox.PasswordChar = false;
            Cuantity_texbox.PlaceholderColor = Color.DarkGray;
            Cuantity_texbox.PlaceholderText = "";
            Cuantity_texbox.ReadOnly = false;
            Cuantity_texbox.Size = new Size(312, 45);
            Cuantity_texbox.TabIndex = 43;
            Cuantity_texbox.TextAlign = ContentAlignment.MiddleLeft;
            Cuantity_texbox.Texts = "";
            Cuantity_texbox.UnderlinedStyle = true;
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(336, 471);
            Controls.Add(Cuantity_texbox);
            Controls.Add(CodeBar_textBox);
            Controls.Add(Price_textbox);
            Controls.Add(NameUser_textBox);
            Controls.Add(Edit_button);
            Controls.Add(Exit_button);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditProduct";
            Load += EditProduct_Load;
            ResumeLayout(false);
        }

        #endregion
        private Components.RJTextBox Catego_textBox;
        private Components.RJTextBox CodeBar_textBox;
        private Components.RJTextBox Price_textbox;
        private Components.RJTextBox NameUser_textBox;
        private Components.RJButton Edit_button;
        private Button Exit_button;
        private Components.RJTextBox Cuantity_texbox;
    }
}