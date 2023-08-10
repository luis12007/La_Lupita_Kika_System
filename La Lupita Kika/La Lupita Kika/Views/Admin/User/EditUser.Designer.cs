namespace La_Lupita_Kika.Views.Admin.User
{
    partial class EditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUser));
            Place_cbb = new Components.RJComboBox();
            RolUser_comboBox = new Components.RJComboBox();
            PasswordUser_textBox = new Components.RJTextBox();
            Username_textBox = new Components.RJTextBox();
            MailUser_textBox = new Components.RJTextBox();
            NameUser_textBox = new Components.RJTextBox();
            Edit_button = new Components.RJButton();
            Exit_button = new Button();
            SuspendLayout();
            // 
            // Place_cbb
            // 
            Place_cbb.BackColor = Color.White;
            Place_cbb.BorderColor = Color.LightSteelBlue;
            Place_cbb.BorderSize = 1;
            Place_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Place_cbb.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Place_cbb.ForeColor = Color.DimGray;
            Place_cbb.IconColor = Color.FromArgb(255, 54, 112);
            Place_cbb.ListBackColor = Color.FromArgb(230, 228, 245);
            Place_cbb.ListTextColor = Color.DodgerBlue;
            Place_cbb.Location = new Point(13, 371);
            Place_cbb.MinimumSize = new Size(200, 30);
            Place_cbb.Name = "Place_cbb";
            Place_cbb.Padding = new Padding(1);
            Place_cbb.Size = new Size(312, 38);
            Place_cbb.TabIndex = 36;
            Place_cbb.Texts = "";
            // 
            // RolUser_comboBox
            // 
            RolUser_comboBox.BackColor = Color.White;
            RolUser_comboBox.BorderColor = Color.LightSteelBlue;
            RolUser_comboBox.BorderSize = 1;
            RolUser_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RolUser_comboBox.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            RolUser_comboBox.ForeColor = Color.DimGray;
            RolUser_comboBox.IconColor = Color.FromArgb(255, 54, 112);
            RolUser_comboBox.ListBackColor = Color.FromArgb(230, 228, 245);
            RolUser_comboBox.ListTextColor = Color.DodgerBlue;
            RolUser_comboBox.Location = new Point(12, 312);
            RolUser_comboBox.MinimumSize = new Size(200, 30);
            RolUser_comboBox.Name = "RolUser_comboBox";
            RolUser_comboBox.Padding = new Padding(1);
            RolUser_comboBox.Size = new Size(312, 38);
            RolUser_comboBox.TabIndex = 35;
            RolUser_comboBox.Texts = "";
            // 
            // PasswordUser_textBox
            // 
            PasswordUser_textBox.BackColor = SystemColors.Window;
            PasswordUser_textBox.BorderColor = Color.FromArgb(255, 54, 112);
            PasswordUser_textBox.BorderFocusColor = Color.HotPink;
            PasswordUser_textBox.BorderRadius = 5;
            PasswordUser_textBox.BorderSize = 2;
            PasswordUser_textBox.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordUser_textBox.ForeColor = Color.FromArgb(64, 64, 64);
            PasswordUser_textBox.Location = new Point(12, 246);
            PasswordUser_textBox.Margin = new Padding(4);
            PasswordUser_textBox.Multiline = false;
            PasswordUser_textBox.Name = "PasswordUser_textBox";
            PasswordUser_textBox.Padding = new Padding(10, 7, 10, 7);
            PasswordUser_textBox.PasswordChar = false;
            PasswordUser_textBox.PlaceholderColor = Color.DarkGray;
            PasswordUser_textBox.PlaceholderText = "";
            PasswordUser_textBox.ReadOnly = false;
            PasswordUser_textBox.Size = new Size(312, 45);
            PasswordUser_textBox.TabIndex = 34;
            PasswordUser_textBox.TextAlign = ContentAlignment.MiddleLeft;
            PasswordUser_textBox.Texts = "";
            PasswordUser_textBox.UnderlinedStyle = true;
            // 
            // Username_textBox
            // 
            Username_textBox.BackColor = SystemColors.Window;
            Username_textBox.BorderColor = Color.FromArgb(255, 54, 112);
            Username_textBox.BorderFocusColor = Color.HotPink;
            Username_textBox.BorderRadius = 5;
            Username_textBox.BorderSize = 2;
            Username_textBox.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Username_textBox.ForeColor = Color.FromArgb(64, 64, 64);
            Username_textBox.Location = new Point(13, 184);
            Username_textBox.Margin = new Padding(4);
            Username_textBox.Multiline = false;
            Username_textBox.Name = "Username_textBox";
            Username_textBox.Padding = new Padding(10, 7, 10, 7);
            Username_textBox.PasswordChar = false;
            Username_textBox.PlaceholderColor = Color.DarkGray;
            Username_textBox.PlaceholderText = "";
            Username_textBox.ReadOnly = false;
            Username_textBox.Size = new Size(312, 45);
            Username_textBox.TabIndex = 33;
            Username_textBox.TextAlign = ContentAlignment.MiddleLeft;
            Username_textBox.Texts = "";
            Username_textBox.UnderlinedStyle = true;
            // 
            // MailUser_textBox
            // 
            MailUser_textBox.BackColor = SystemColors.Window;
            MailUser_textBox.BorderColor = Color.FromArgb(255, 54, 112);
            MailUser_textBox.BorderFocusColor = Color.HotPink;
            MailUser_textBox.BorderRadius = 5;
            MailUser_textBox.BorderSize = 2;
            MailUser_textBox.Font = new Font("Bahnschrift", 15F, FontStyle.Regular, GraphicsUnit.Point);
            MailUser_textBox.ForeColor = Color.FromArgb(64, 64, 64);
            MailUser_textBox.Location = new Point(13, 121);
            MailUser_textBox.Margin = new Padding(4);
            MailUser_textBox.Multiline = false;
            MailUser_textBox.Name = "MailUser_textBox";
            MailUser_textBox.Padding = new Padding(10, 7, 10, 7);
            MailUser_textBox.PasswordChar = false;
            MailUser_textBox.PlaceholderColor = Color.DarkGray;
            MailUser_textBox.PlaceholderText = "";
            MailUser_textBox.ReadOnly = false;
            MailUser_textBox.Size = new Size(312, 45);
            MailUser_textBox.TabIndex = 32;
            MailUser_textBox.TextAlign = ContentAlignment.MiddleLeft;
            MailUser_textBox.Texts = "";
            MailUser_textBox.UnderlinedStyle = true;
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
            NameUser_textBox.TabIndex = 31;
            NameUser_textBox.TextAlign = ContentAlignment.MiddleLeft;
            NameUser_textBox.Texts = "";
            NameUser_textBox.UnderlinedStyle = true;
            NameUser_textBox._TextChanged += NameUser_textBox__TextChanged;
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
            Edit_button.Location = new Point(43, 451);
            Edit_button.Name = "Edit_button";
            Edit_button.Size = new Size(250, 118);
            Edit_button.TabIndex = 30;
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
            Exit_button.TabIndex = 29;
            Exit_button.UseVisualStyleBackColor = false;
            Exit_button.Click += Exit_button_Click;
            // 
            // EditUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(345, 601);
            Controls.Add(Place_cbb);
            Controls.Add(RolUser_comboBox);
            Controls.Add(PasswordUser_textBox);
            Controls.Add(Username_textBox);
            Controls.Add(MailUser_textBox);
            Controls.Add(NameUser_textBox);
            Controls.Add(Edit_button);
            Controls.Add(Exit_button);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditUser";
            Load += EditUser_Load;
            ResumeLayout(false);
        }

        #endregion

        private Components.RJComboBox Place_cbb;
        private Components.RJComboBox RolUser_comboBox;
        private Components.RJTextBox PasswordUser_textBox;
        private Components.RJTextBox Username_textBox;
        private Components.RJTextBox MailUser_textBox;
        private Components.RJTextBox NameUser_textBox;
        private Components.RJButton Edit_button;
        private Button Exit_button;
    }
}