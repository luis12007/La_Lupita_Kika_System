namespace La_Lupita_Kika.Views
{
    partial class CreateUser
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
            exit_button = new Button();
            AddUser_button = new Button();
            delete_filds = new Button();
            name = new Label();
            Rol = new Label();
            NameUser_textBox = new TextBox();   
            RolUser_comboBox = new ComboBox();
            Password = new Label();
            PasswordUser_textBox = new TextBox();
            Username_textBox = new TextBox();
            Username = new Label();
            Mail = new Label();
            MailUser_textBox = new TextBox();
            SuspendLayout();
            // 
            // exit_button
            // 
            exit_button.Location = new Point(22, 12);
            exit_button.Name = "exit_button";
            exit_button.Size = new Size(94, 29);
            exit_button.TabIndex = 0;
            exit_button.Text = "<-";
            exit_button.UseVisualStyleBackColor = true;
            // 
            // AddUser_button
            // 
            AddUser_button.Location = new Point(41, 391);
            AddUser_button.Name = "AddUser_button";
            AddUser_button.Size = new Size(94, 29);
            AddUser_button.TabIndex = 1;
            AddUser_button.Text = "Agregar";
            AddUser_button.UseVisualStyleBackColor = true;
            AddUser_button.Click += AddUser_button_Click;
            // 
            // delete_filds
            // 
            delete_filds.Location = new Point(289, 391);
            delete_filds.Name = "delete_filds";
            delete_filds.Size = new Size(94, 29);
            delete_filds.TabIndex = 2;
            delete_filds.Text = "Limpiar";
            delete_filds.UseVisualStyleBackColor = true;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(22, 76);
            name.Name = "name";
            name.Size = new Size(64, 20);
            name.TabIndex = 3;
            name.Text = "Nombre";
            // 
            // Rol
            // 
            Rol.AutoSize = true;
            Rol.Location = new Point(406, 111);
            Rol.Name = "Rol";
            Rol.Size = new Size(31, 20);
            Rol.TabIndex = 4;
            Rol.Text = "Rol";
            Rol.Click += label2_Click;
            // 
            // NameUser_textBox
            // 
            NameUser_textBox.Location = new Point(22, 108);
            NameUser_textBox.Name = "NameUser_textBox";
            NameUser_textBox.PlaceholderText = "Alex";
            NameUser_textBox.Size = new Size(125, 27);
            NameUser_textBox.TabIndex = 5;
            // 
            // RolUser_comboBox
            // 
            RolUser_comboBox.FormattingEnabled = true;
            RolUser_comboBox.Items.AddRange(new object[] { "Staff", "Admin" });
            RolUser_comboBox.Location = new Point(406, 145);
            RolUser_comboBox.Name = "RolUser_comboBox";
            RolUser_comboBox.Size = new Size(151, 28);
            RolUser_comboBox.TabIndex = 6;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(22, 177);
            Password.Name = "Password";
            Password.Size = new Size(83, 20);
            Password.TabIndex = 7;
            Password.Text = "Contraseña";
            // 
            // PasswordUser_textBox
            // 
            PasswordUser_textBox.Location = new Point(22, 210);
            PasswordUser_textBox.Name = "PasswordUser_textBox";
            PasswordUser_textBox.PlaceholderText = "pass";
            PasswordUser_textBox.Size = new Size(125, 27);
            PasswordUser_textBox.TabIndex = 8;
            // 
            // Username_textBox
            // 
            Username_textBox.Location = new Point(228, 108);
            Username_textBox.Name = "Username_textBox";
            Username_textBox.PlaceholderText = "Alex12007";
            Username_textBox.Size = new Size(125, 27);
            Username_textBox.TabIndex = 9;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Location = new Point(228, 76);
            Username.Name = "Username";
            Username.Size = new Size(75, 20);
            Username.TabIndex = 10;
            Username.Text = "Username";
            // 
            // Mail
            // 
            Mail.AutoSize = true;
            Mail.Location = new Point(228, 177);
            Mail.Name = "Mail";
            Mail.Size = new Size(38, 20);
            Mail.TabIndex = 11;
            Mail.Text = "Mail";
            // 
            // MailUser_textBox
            // 
            MailUser_textBox.Location = new Point(228, 210);
            MailUser_textBox.Name = "MailUser_textBox";
            MailUser_textBox.PlaceholderText = "alexhdz@gmail.com";
            MailUser_textBox.Size = new Size(209, 27);
            MailUser_textBox.TabIndex = 12;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 459);
            Controls.Add(MailUser_textBox);
            Controls.Add(Mail);
            Controls.Add(Username);
            Controls.Add(Username_textBox);
            Controls.Add(PasswordUser_textBox);
            Controls.Add(Password);
            Controls.Add(RolUser_comboBox);
            Controls.Add(NameUser_textBox);
            Controls.Add(Rol);
            Controls.Add(name);
            Controls.Add(delete_filds);
            Controls.Add(AddUser_button);
            Controls.Add(exit_button);
            Name = "CreateUser";
            Text = "CreateUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exit_button;
        private Button AddUser_button;
        private Button delete_filds;
        private Label name;
        private Label Rol;
        private TextBox NameUser_textBox;
        private ComboBox RolUser_comboBox;
        private Label Password;
        private TextBox PasswordUser_textBox;
        private TextBox Username_textBox;
        private Label Username;
        private Label Mail;
        private TextBox MailUser_textBox;
    }
}